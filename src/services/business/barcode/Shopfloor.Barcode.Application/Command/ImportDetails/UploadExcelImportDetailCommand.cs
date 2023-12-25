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
        private readonly ILocationRepository _locationRepository;
        public IArticleBarcodeRepository _articleBarcodeRepository;

        public UploadExcelImportDetailCommandHandler(ILocationRepository locationRepository,
             IArticleBarcodeRepository articleBarcodeRepository)
        {
            _articleBarcodeRepository = articleBarcodeRepository;
            _locationRepository = locationRepository;
        }

        public async Task<Response<List<UploadExcelImportDetailModel>>> Handle(UploadExcelImportDetailCommand request, CancellationToken cancellationToken)
        {
            var input = new ImportExcelModel(0, 2, FieldMaps.ImportDetails);
            var data = ImportExcelHelper.ReadExcel<UploadExcelImportDetailModel>(request.File, input);
            var locationItems = data.Where(x => !string.IsNullOrEmpty(x.Location));
            string[] locationCodes = locationItems.Select(x => x.Location).ToArray();
            var dicLocation = await _locationRepository.GetByCodesAsync(locationCodes);
            var notValidLocations = data.Where(x => !string.IsNullOrEmpty(x.Location) && !dicLocation.ContainsKey(x.Location)).ToList();
            if (notValidLocations.Any())
            {
                var errors = notValidLocations.Select(x => new Error { Message = x.Location + " is not valid" }).ToList();
                return new Response<List<UploadExcelImportDetailModel>>() { Errors = errors, Succeeded = false, Message = "Locations are not valid" };
            }
            else
                foreach (var item in locationItems)
                {
                    if (dicLocation.ContainsKey(item.Location))
                    {
                        item.LocationId = dicLocation[item.Location];
                    }
                };
            if (request.ImportType == ImportType.ImportTransferToSite)
            {
                var barcodeItems = data.Where(x => !string.IsNullOrEmpty(x.BarCode));
                var barCodes = barcodeItems.Select(x => x.BarCode).ToArray();
                var dicArticleBarCode = await _articleBarcodeRepository.GetByBarCodesAsync(barCodes);
                var notValidBarCodes = data.Where(x => !string.IsNullOrEmpty(x.BarCode) && !dicArticleBarCode.ContainsKey(x.BarCode)).ToList();
                if (notValidBarCodes.Any())
                {
                    var errors = notValidLocations.Select(x => new Error { Message = x.BarCode + " is not valid" }).ToList();
                    return new Response<List<UploadExcelImportDetailModel>>() { Errors = errors, Succeeded = false, Message = "BarCodes are not valid" };
                }
                else
                    foreach (var item in barcodeItems)
                    {
                        if (dicArticleBarCode.ContainsKey(item.BarCode))
                        {
                            item.ArticleBarCodeId = dicArticleBarCode[item.BarCode].Id;
                        }
                    };
            }

            return new Response<List<UploadExcelImportDetailModel>>(data);
        }
    }
}
