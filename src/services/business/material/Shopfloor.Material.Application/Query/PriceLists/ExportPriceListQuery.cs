using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Core.Helpers;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Query.PriceLists
{
    public class ExportPriceListQuery : IRequest<FileContentResult>
    {
        public int[] Ids { get; set; }
    }

    public class ExportPriceListQueryHandler : IRequestHandler<ExportPriceListQuery, FileContentResult>
    {
        private readonly IPriceListRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExportPriceListQueryHandler(
            IPriceListRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FileContentResult> Handle(ExportPriceListQuery request, CancellationToken cancellationToken)
        {
            if (request.Ids == null || request.Ids.Length == 0)
                throw new ArgumentNullException(nameof(request.Ids));
            var data = new List<Dictionary<string, object>>();
            var priceLists = await _repository.GetPriceListByIdsAsync(request.Ids);
            foreach (var priceList in priceLists)
            {
                foreach (var item in priceList.PriceListDetails)
                {
                    data.Add(CellData(priceList, item));
                }
            }

            if (data.Count == 0)
                throw new Exception("Not found data");
            var fname = "SupplierPriceList.xls";
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, "TemplateWFX", fname);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fname);
            var ms = ExportExcelHelper.WriteExcelHSSF(fullPath, new ExcelInputDataModel
            {
                Data = data,
                RowIndex = 1,
                SheetIndex = 0
            });
            return new FileContentResult(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fname,
                EnableRangeProcessing = true,
            };
        }

        private Dictionary<string, object> CellData(PriceList priceList, PriceListDetail detail)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("A", priceList.SupplierCode);
            dic.Add("B", detail.ArticleCode);
            dic.Add("C", string.Join(',', detail.PriceListDetailColors?.Select(x => x.Code)));
            dic.Add("D", string.Join(',', detail.PriceListDetailColors?.Select(x => x.Name)));
            dic.Add("E", string.Join(',', detail.PriceListDetailSizes?.Select(x => x.Code)));
            dic.Add("F", detail.DeliveryTerm);
            dic.Add("G", detail.Price);
            dic.Add("H", detail.Currency);
            dic.Add("I", detail.ValidFrom.ToString("d"));
            dic.Add("J", detail.ValidTo.HasValue ? detail.ValidTo.Value.ToString("d") : detail.ValidTo);
            dic.Add("K", detail.Uom);
            return dic;
        }
    }
}