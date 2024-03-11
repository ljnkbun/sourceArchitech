using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportDetails
{
    public class CreateImportDetailCommand : IRequest<Response<int>>
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string PONo { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; } = 0;
        public decimal? WeightPerCone { get; set; } = 0;
        public string Note { get; set; }
        public int? ImportArticleId { get; set; }
        public int? AriticleBarcodeId { get; set; }
        public string AriticleBarcode { get; set; }
        public string Location { get; set; }
        public string LotNo { get; set; }
        public string Site { get; set; }
        public int? LocationId { get; set; }
        public ImportType? Type { get; set; }
    }

    public class CreateImportDetailCommandHandler : IRequestHandler<CreateImportDetailCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IImportDetailRepository _repository;
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;
        public CreateImportDetailCommandHandler(IMapper mapper,
            IImportDetailRepository repository
            , IArticleBarcodeRepository articleBarcodeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _articleBarcodeRepository = articleBarcodeRepository;
        }

        public async Task<Response<int>> Handle(CreateImportDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ImportDetail>(request);
            if (request.Type == ImportType.ImportTransferToSite)
            {
                var articleBarcode = await _articleBarcodeRepository.GetByBarcodeAsync(request.AriticleBarcode);
                if (articleBarcode == null)
                {
                    await _repository.GenBarCode(entity.UOM, new List<ImportDetail>() { entity } );
                }
                else if (articleBarcode.CurrentLocationId != request.LocationId)
                {
                    articleBarcode.CurrentLocationId = request.LocationId;
                }
                await _repository.AddImportDetailHasBarCodeAsync(entity, articleBarcode);
            }
            if (request.Type == ImportType.ImportPO)
            {
                await _repository.GenBarCode(entity.UOM, new List<ImportDetail>() { entity });
                await _repository.AddAsync(entity);
            }
            return new Response<int>(entity.Id);
        }
    }
}
