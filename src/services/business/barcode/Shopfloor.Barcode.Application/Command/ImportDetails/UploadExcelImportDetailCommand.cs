using MediatR;
using Microsoft.AspNetCore.Http;
using Shopfloor.Barcode.Application.Definitions;
using Shopfloor.Barcode.Application.Models.ImportPODetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Excels;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class UploadExcelImportDetailCommand : IRequest<Response<List<UploadExcelImportDetailModel>>>
    {
        public IFormFile File { get; set; }
        public ImportType ImportType { get; set; }
    }

    public class UploadExcelImportDetailCommandHandler : IRequestHandler<UploadExcelImportDetailCommand, Response<List<UploadExcelImportDetailModel>>>
    {
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;

        public UploadExcelImportDetailCommandHandler(ILocationRepository locationRepository,
             IArticleBarcodeRepository articleBarcodeRepository)
        {
            _articleBarcodeRepository = articleBarcodeRepository;
        }

        public async Task<Response<List<UploadExcelImportDetailModel>>> Handle(UploadExcelImportDetailCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.ImportDetails);
            var data = ImportExcelHelper.ReadExcel<UploadExcelImportDetailModel>(request.File, input);
            if (data == null || !data.Any())
                return new Response<List<UploadExcelImportDetailModel>>(null, "No data import");
            foreach (var item in data)
            {
                if (item.QuantityMeter.HasValue) item.UOM = "METER";
                else if (item.QuantityYard.HasValue) item.UOM = "YARD";
                item.WeightPerCone = null;
                item.NumberOfCone = null;
            }
            if (request.ImportType == ImportType.ImportTransferToSite)
            {
                var barcodeItems = data.Where(x => !string.IsNullOrEmpty(x.BarCode));
                var dicArticleBarCode = await _articleBarcodeRepository.GetByBarCodesAsync(barcodeItems.Select(x => x.BarCode).ToArray());
                var notValidBarCodes = data.Where(x => !string.IsNullOrEmpty(x.BarCode) && !dicArticleBarCode.ContainsKey(x.BarCode)).ToList();
                if (notValidBarCodes.Any())
                {
                    var errors = notValidBarCodes.Select(x => new Error { Message = x.BarCode + " is not valid" }).ToList();
                    return new Response<List<UploadExcelImportDetailModel>>() { Errors = errors, Succeeded = false, Message = "BarCodes are not valid" };
                }
                foreach (var item in barcodeItems)
                {
                    if (dicArticleBarCode.TryGetValue(item.BarCode, out var barCode))
                    {
                        item.ArticleBarCodeId = barCode.Id;
                    }
                };
            }

            return new Response<List<UploadExcelImportDetailModel>>(data);
        }
    }
}
