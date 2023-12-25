using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shopfloor.Core.Helpers;

namespace Shopfloor.Barcode.Application.Query.ImportDetails
{
    public class ExportExcelImportDetailsQuery : IRequest<FileContentResult>
    {

    }
    public class ExportExcelImportDetailsQueryHandler : IRequestHandler<ExportExcelImportDetailsQuery, FileContentResult>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ExportExcelImportDetailsQueryHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public  Task<FileContentResult> Handle(ExportExcelImportDetailsQuery request, CancellationToken cancellationToken)
        {
            var fname = "ImportDetail.xls";
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, "TemplateWFX", fname);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fname);
            var ms = ExportExcelHelper.WriteExcelHSSF(fullPath, new ExcelInputDataModel
            {
                Data = new List<Dictionary<string, object>>(),
                RowIndex = 1,
                SheetIndex = 0
            });
            return Task.FromResult( new FileContentResult(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = fname,
                EnableRangeProcessing = true,
            });
        }
    } 
}
