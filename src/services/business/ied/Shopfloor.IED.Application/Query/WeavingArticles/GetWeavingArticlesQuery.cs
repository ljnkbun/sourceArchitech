using AutoMapper;
using MediatR;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingArticles;
using Shopfloor.IED.Application.Parameters.WeavingArticles;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingArticles
{
    public class GetWeavingArticlesQuery : IRequest<PagedResponse<IReadOnlyList<WeavingArticleModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? WeavingIEDId { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool? Deleted { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"WeavingArticles";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetWeavingArticlesQueryHandler : IRequestHandler<GetWeavingArticlesQuery, PagedResponse<IReadOnlyList<WeavingArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingArticleRepository _repository;
        public GetWeavingArticlesQueryHandler(IMapper mapper,
            IWeavingArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<WeavingArticleModel>>> Handle(GetWeavingArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WeavingArticleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<WeavingArticleParameter, WeavingArticleModel>(validFilter);
        }
    }
}
