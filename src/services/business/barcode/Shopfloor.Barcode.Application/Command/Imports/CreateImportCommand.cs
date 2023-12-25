using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class CreateImportCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ImportType? Type { get; set; }
        public  ICollection<CreateImportArticleCommand> ImportArticles { get; set; }

    }
    public class CreateImportCommandHandler : IRequestHandler<CreateImportCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IImportRepository _repository;
        private readonly IImportDetailRepository _repositoryImportDetail;
        private readonly ILocationRepository _locationRepository;
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;
        public CreateImportCommandHandler(IMapper mapper, ILogger<CreateImportCommand> logger,
            IImportRepository repository, IImportDetailRepository repositoryImportDetail,
                ILocationRepository locationRepository
            , IArticleBarcodeRepository articleBarcodeRepository)
        {
            _repository = repository;
            _repositoryImportDetail = repositoryImportDetail;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _articleBarcodeRepository = articleBarcodeRepository;
        }
       
        public async Task<Response<int>> Handle(CreateImportCommand request,
            CancellationToken cancellationToken)
        {
            var newDetails = request.ImportArticles.SelectMany(x => x.ImportDetails);
            Import entity =  _mapper.Map<Import>(request);
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
                await _repository.AddImportHasBarCodeAsync(entity, articleBarcodes);
            }
            if (request.Type == ImportType.ImportPO)
            {
                var details = entity.ImportArticles.SelectMany(x => x.ImportDetails).ToList();
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
