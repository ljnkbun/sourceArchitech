using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Helpers;

namespace Shopfloor.Barcode.Application.Query.ExportDetails
{
    public class ExportDataExportDetailsQuery : IRequest<FileContentResult>
    {
        public string Ids { get; set; }
    }
    public class ExportDataExportDetailsQueryHandler : IRequestHandler<ExportDataExportDetailsQuery, FileContentResult>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IExportDetailRepository _ExportDetailRepository;

        public ExportDataExportDetailsQueryHandler(IWebHostEnvironment webHostEnvironment,
            IExportDetailRepository ExportDetailRepository
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _ExportDetailRepository = ExportDetailRepository;
        }
        public async Task<FileContentResult> Handle(ExportDataExportDetailsQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Ids))
                throw new ArgumentNullException(nameof(request.Ids));
            var ids = request.Ids.Split(",").Select(int.Parse).ToArray();
            var data = new List<Dictionary<string, object>>();
            var details = await _ExportDetailRepository.GetByIdsAsync(ids);
            foreach (var ExportDetail in details)
                data.Add(CellData(ExportDetail));

            if (data.Count == 0)
                throw new Exception("Not found data");
            var fname = "ExportDetails.xls";
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


        private Dictionary<string, object> CellData(ExportDetail ExportDetail)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("A", ExportDetail.Name);
            dic.Add("B", ExportDetail.Code);
            dic.Add("C", ExportDetail.ArticleBarcode);
            dic.Add("D", ExportDetail.Yard);
            dic.Add("E", ExportDetail.Meter);
            dic.Add("F", ExportDetail.Unit);
            dic.Add("G", ExportDetail.Shade);
            dic.Add("H", ExportDetail.OC);
            dic.Add("I", ExportDetail.Size);
            dic.Add("J", ExportDetail.Color);
            dic.Add("K", ExportDetail.Note);
            return dic;
        }
    }
}
