using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.ImportArticles
{
    public class CreateImportArticleCommand : IRequest<Response<int>>
    {
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string GDNNumber { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string SupplierName { get; set; }
        public string OrderRefNum { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public string UOM { get; set; }
        public decimal? Units { get; set; }
        public string OCNum { get; set; }
        public ImportType? Type { get; set; }
        public ICollection<CreateImportDetailCommand> ImportDetails { get; set; }
    }

    public class CreateImportArticleCommandHandler : IRequestHandler<CreateImportArticleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IImportArticleRepository _repository;
        private readonly IImportDetailRepository _repositoryImportDetail;
        private readonly ILocationRepository _locationRepository;
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;
        public CreateImportArticleCommandHandler(IMapper mapper,
            IImportArticleRepository repository, IImportDetailRepository repositoryImportDetail,
            ILocationRepository locationRepository
            , IArticleBarcodeRepository articleBarcodeRepository)
        {
            _repository = repository;
            _repositoryImportDetail = repositoryImportDetail;
            _mapper = mapper;
            _locationRepository = locationRepository;
            _articleBarcodeRepository = articleBarcodeRepository;
        }
       
        public async Task<Response<int>> Handle(CreateImportArticleCommand request, CancellationToken cancellationToken)
        {
            var newDetails = request.ImportDetails;
            
            ImportArticle entity = _mapper.Map<Domain.Entities.ImportArticle>(request); ;
            if (request.Type == ImportType.ImportTransferToSite)
            {
                var articleBarcodes = new List<ArticleBarcode>();
                var ariticleBarcodeIds = newDetails.Select(x => x.AriticleBarcodeId).ToArray();
                var dicArticleBarCode = await _articleBarcodeRepository.GetByBarIdsAsync(ariticleBarcodeIds);
                foreach (var item in newDetails)
                {
                    if (dicArticleBarCode.ContainsKey(item.AriticleBarcodeId))
                    {
                        var articleBarcode = dicArticleBarCode[item.AriticleBarcodeId];
                        if (articleBarcode.CurrentLocationId != item.LocationId)
                        {
                            articleBarcode.CurrentLocationId = item.LocationId;
                            articleBarcodes.Add(articleBarcode);
                        }

                    }
                };
                await _repository.AddImportArticleHasBarCodeAsync(entity, articleBarcodes);
            }
            if (request.Type == ImportType.ImportPO)
            {
                var details = entity.ImportDetails;
                if (details.Any())
                {
                    var barcodes = await _repositoryImportDetail.GenBarCode(details.FirstOrDefault()?.UOM, details);
                    if (!barcodes.Any()) throw new ApiException($"Error Generate Barcode");
                }
                await _repository.AddAsync(entity);

            }
            return new Response<int>(entity.Id);
        }
    }
}
