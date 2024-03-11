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
        private readonly IExportDetailRepository _exportDetailRepository;

        public ExportDataExportDetailsQueryHandler(IWebHostEnvironment webHostEnvironment,
            IExportDetailRepository ExportDetailRepository
            )
        {
            _webHostEnvironment = webHostEnvironment;
            _exportDetailRepository = ExportDetailRepository;
        }
        public async Task<FileContentResult> Handle(ExportDataExportDetailsQuery request, CancellationToken cancellationToken)
        {
            var data = new List<Dictionary<string, object>>();
            if (!string.IsNullOrEmpty(request.Ids))
            {
                var ids = request.Ids.Split(",").Select(int.Parse).ToArray();
                var details = await _exportDetailRepository.GetByIdsAsync(ids);
                foreach (var ExportDetail in details)
                    data.Add(CellData(ExportDetail));
            }

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


        private static Dictionary<string, object> CellData(ExportDetail exportDetail)
        {
            return new Dictionary<string, object>
            {
                { "A", exportDetail.Name },
                { "B", exportDetail.Code },
                { "C", exportDetail.ArticleBarcode },
                { "D", string.Empty },
                { "E", string.Empty },
                { "F", exportDetail.Quantity },
                { "G", exportDetail.Shade },
                { "H", exportDetail.OC },
                { "I", exportDetail.SizeCode },
                { "J", exportDetail.ColorCode },
                { "K", exportDetail.Note }
            };
        }
    }
}
