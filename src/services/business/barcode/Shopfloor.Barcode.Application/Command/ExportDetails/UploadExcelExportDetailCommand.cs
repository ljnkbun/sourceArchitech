using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Barcode.Application.Definitions;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ExportDetails
{
    public class UploadExcelExportDetailCommand : IRequest<Response<List<ExportDetailExcelModel>>>
    {
        public IFormFile File { get; set; }

    }

    public class ImportDataExportDetailCommandHandler : IRequestHandler<UploadExcelExportDetailCommand, Response<List<ExportDetailExcelModel>>>
    {
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;
        public ImportDataExportDetailCommandHandler(ILocationRepository locationRepository
            , IArticleBarcodeRepository articleBarcodeRepository)
        {
            _articleBarcodeRepository = articleBarcodeRepository;
        }

        public async Task<Response<List<ExportDetailExcelModel>>> Handle(UploadExcelExportDetailCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.ExportDetail);
            var data = ImportExcelHelper.ReadExcel<ExportDetailExcelModel>(request.File, input);
            if (data == null || !data.Any())
                return new Response<List<ExportDetailExcelModel>>(null, "No data import");
            var barcodeItems = data.Where(x => !string.IsNullOrEmpty(x.Barcode));
            var dicArticleBarCode = await _articleBarcodeRepository.GetByBarCodesAsync(barcodeItems.Select(x => x.Barcode).ToArray());
            var notValidBarCodes = data.Where(x => !string.IsNullOrEmpty(x.Barcode) && !dicArticleBarCode.ContainsKey(x.Barcode)).ToList();
            if (notValidBarCodes.Any())
            {
                var errors = notValidBarCodes.Select(x => new Error { Message = x.Barcode + " is not valid" }).ToList();
                return new Response<List<ExportDetailExcelModel>>() { Errors = errors, Succeeded = false, Message = "BarCodes are not valid" };
            }
            foreach (var item in barcodeItems)
            {
                if (dicArticleBarCode.TryGetValue(item.Barcode, out var barCode))
                {
                    item.ArticleBarcCodeId = barCode.Id;
                }
            }
            return new Response<List<ExportDetailExcelModel>>(data);
        }
    }
}
