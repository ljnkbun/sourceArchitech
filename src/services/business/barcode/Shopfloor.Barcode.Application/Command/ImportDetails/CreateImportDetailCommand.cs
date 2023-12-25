using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class CreateImportDetailCommand : IRequest<Response<int>>
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Note { get; set; }
        public int ImportArticleId { get; set; }
        public int AriticleBarcodeId { get; set; }
        public int LocationId { get; set; }
        public ImportType? Type { get; set; }
    }

    public class CreateImportDetailCommandHandler : IRequestHandler<CreateImportDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IImportDetailRepository _repository;
        private readonly ILocationRepository _locationRepository;
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;
        public CreateImportDetailCommandHandler(IMapper mapper,
            IImportDetailRepository repository,
             ILocationRepository locationRepository
            , IArticleBarcodeRepository articleBarcodeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _locationRepository = locationRepository;
            _articleBarcodeRepository = articleBarcodeRepository;
        }
     
        public async Task<Response<int>> Handle(CreateImportDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.ImportDetail>(request);
            if (request.Type == ImportType.ImportTransferToSite)
            {
                var articleBarcode = await _articleBarcodeRepository.GetByIdAsync(request.AriticleBarcodeId);
                if (articleBarcode.CurrentLocationId != request.LocationId)
                {
                    articleBarcode.CurrentLocationId = request.LocationId;
                }
                await _repository.AddImportDetailHasBarCodeAsync(entity, articleBarcode);
            }
            if (request.Type == ImportType.ImportPO)
            {
                var barcodes = await _repository.GenBarCode(entity.UOM, new List<ImportDetail>() { entity });
                if (!barcodes.Any()) throw new ApiException($"Error Generate Barcode");
                await _repository.AddAsync(entity);
            }
            return new Response<int>(entity.Id);
        }
    }
}
