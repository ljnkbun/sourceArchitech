using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Imports;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Imports
{
    public class GetImportQuery : IRequest<Response<ImportModel>>
    {
        public int Id { get; set; }
    }
    public class GetImportQueryHandler : IRequestHandler<GetImportQuery, Response<ImportModel>>
    {
        private readonly IMapper _mapper;
        private readonly IImportRepository _repository;
        private readonly IWfxPOArticleRepository _wfxPOArticleRepository;

        public GetImportQueryHandler(IMapper mapper,
            IImportRepository repository
            , IWfxPOArticleRepository wfxPOArticleRepository
            )
        {
            _mapper = mapper;
            _repository = repository;
            _wfxPOArticleRepository = wfxPOArticleRepository;
        }

        public async Task<Response<ImportModel>> Handle(GetImportQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.ViewImportByIdAsync(query.Id);
            if (entity == null) return new($"Import Not Found (Id:{query.Id}).");
            var rs = _mapper.Map<ImportModel>(entity);

            var wfxPOArticles = await _wfxPOArticleRepository.GetByOrderRefsAsync(entity.ImportArticles.Select(x => x.OrderRefNum).ToArray());

            var masters = _mapper.Map<List<WfxPOArticleMasterModel>>(wfxPOArticles);
            var groupByData = masters.GroupBy(x => new { x.ArticleCode, x.OrderRefNum });

            foreach (var entry in groupByData)
            {
                var articleModele = _mapper.Map<WfxPOArticleParentModel>(entry.FirstOrDefault());
                var importArticle = rs.ImportArticleModels.FirstOrDefault(x => x.ArticleCode == articleModele.ArticleCode && x.OrderRefNum == articleModele.OrderRefNum);
                if (importArticle == null) continue;

                var lstEntityModel = masters.Where(x => x.ArticleCode == entry.Key.ArticleCode && x.OrderRefNum == entry.Key.OrderRefNum);
                if (lstEntityModel.Any())
                {
                    importArticle.WfxPOArticleChildModels = _mapper.Map<List<WfxPOArticleChildModel>>(lstEntityModel);
                }
            }

            return new Response<ImportModel>(rs);
        }
    }
}
