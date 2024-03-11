using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.WfxPOArticles
{
    public class GetWfxPOArticleByArticleCodeOrderRefQuery : IRequest<Response<WfxPOArticleParentModel>>
    {
        public string ArticleCode { get; set; }
        public string OrderRefNum { get; set; }
    }
    public class GetWfxPOArticleByArticleCodeOrderRefQueryHandler : IRequestHandler<GetWfxPOArticleByArticleCodeOrderRefQuery, Response<WfxPOArticleParentModel>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxPOArticleRepository _repository;
        public GetWfxPOArticleByArticleCodeOrderRefQueryHandler(IMapper mapper,
            IWfxPOArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<WfxPOArticleParentModel>> Handle(GetWfxPOArticleByArticleCodeOrderRefQuery query, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByArticleCodeOrderRefAsync(query.ArticleCode, query.OrderRefNum);
            if (entities == null || !entities.Any()) return new($"Recipe Unit Not Found (ArticleCode:{query.ArticleCode}), OrderRefNum:{query.OrderRefNum}).");

            var master = _mapper.Map<List<WfxPOArticleMasterModel>>(entities);

            var articleModel = _mapper.Map<WfxPOArticleParentModel>(master.FirstOrDefault());
            articleModel.WfxPOArticleChildModels = _mapper.Map<List<WfxPOArticleChildModel>>(master);

            return new Response<WfxPOArticleParentModel>(articleModel);
        }
    }
}
