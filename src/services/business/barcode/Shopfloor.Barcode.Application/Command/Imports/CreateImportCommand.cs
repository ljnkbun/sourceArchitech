using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.Imports
{
    public class CreateImportCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public ImportType? Type { get; set; }
        public ImportStatus? Status { get; set; }
        public ICollection<CreateImportArticleCommand> ImportArticles { get; set; }

    }
    public class CreateImportCommandHandler : IRequestHandler<CreateImportCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        private readonly IImportRepository _repository;
        private readonly IImportDetailRepository _repositoryImportDetail;
        private readonly IArticleBarcodeRepository _articleBarcodeRepository;
        public CreateImportCommandHandler(IMapper mapper,
            IImportRepository repository, IImportDetailRepository repositoryImportDetail
            , IArticleBarcodeRepository articleBarcodeRepository)
        {
            _repository = repository;
            _repositoryImportDetail = repositoryImportDetail;
            _mapper = mapper;
            _articleBarcodeRepository = articleBarcodeRepository;
        }

        public async Task<Response<int>> Handle(CreateImportCommand request,
            CancellationToken cancellationToken)
        {
            var newDetails = request.ImportArticles.SelectMany(x => x.ImportDetails);
            Import entity = _mapper.Map<Import>(request);
            if (request.Type == ImportType.ImportTransferToSite)
            {
                var articleBarcodes = new List<ArticleBarcode>();
                Dictionary<string, ArticleBarcode> dicArticleBarCodeStr = await _articleBarcodeRepository.GetByBarCodesAsync(newDetails.Select(x => x.AriticleBarcode).ToArray());

                if (dicArticleBarCodeStr?.Any() ?? false)
                {
                    foreach (var item in newDetails)
                    {
                        if (dicArticleBarCodeStr.TryGetValue(item.AriticleBarcode, out ArticleBarcode articleBarcode))
                        {
                            articleBarcode.CurrentLocationId = item.LocationId;
                            item.AriticleBarcodeId = articleBarcode.Id;
                            articleBarcodes.Add(articleBarcode);
                        }
                    }
                }

                await _repository.AddImportHasBarCodeAsync(entity, articleBarcodes);
            }
            else if (request.Type == ImportType.ImportPO)
            {
                var details = entity.ImportArticles.SelectMany(x => x.ImportDetails).ToList();
                if (details.Any())
                {
                    await _repositoryImportDetail.GenBarCode(details.FirstOrDefault()?.UOM, entity.ImportArticles);
                }
                await _repository.AddAsync(entity);

            }

            return new Response<int>(entity.Id);
        }
    }
}
