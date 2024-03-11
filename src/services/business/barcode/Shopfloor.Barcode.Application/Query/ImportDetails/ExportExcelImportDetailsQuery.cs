using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Application.Models.ImportPODetails;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Helpers;

namespace Shopfloor.Barcode.Application.Query.ImportDetails
{
    public class ExportExcelImportDetailsQuery : IRequest<FileContentResult>
    {
        public string Ids { get; set; }
    }
    public class ExportExcelImportDetailsQueryHandler : IRequestHandler<ExportExcelImportDetailsQuery, FileContentResult>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImportDetailRepository _repository;

        public ExportExcelImportDetailsQueryHandler(
            IWebHostEnvironment webHostEnvironment
            , IImportDetailRepository repository
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _repository = repository;
        }
        public async Task<FileContentResult> Handle(ExportExcelImportDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(request.Ids))
            {
                var ids = request.Ids.Split(",").Select(int.Parse).ToArray();
                var details = await _repository.GetByIdsAsync(ids);
                foreach (var ImportDetail in details)
                    data.Add(CellData(ImportDetail));
            }

            var fname = "ImportDetail.xls";
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

        private static Dictionary<string, object> CellData(ImportDetail importDetail)
        {
            return new Dictionary<string, object>
            {
                { "A", importDetail.ArticleName },
                { "B", importDetail.ArticleCode },
                { "C", importDetail.Quantity },
                { "D", importDetail.UOM },
                { "E", importDetail.Quantity },
                { "F", importDetail.ArticleBarcode.Barcode },
                { "G", importDetail.Status },
                { "H", importDetail.Shade },
                { "I", importDetail.PONo },
                { "J", importDetail.OC },
                { "K", importDetail.Color },
                { "L", importDetail.Size },
                { "M", importDetail.Location },
                { "N", importDetail.NumberOfCone },
                { "O", importDetail.WeightPerCone },
                { "P", importDetail.Note }
            };
        }
    }

}
