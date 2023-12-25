using AutoMapper;
using MediatR;
using Shopfloor.Barcode.Application.Models.Articles;
using Shopfloor.Barcode.Application.Parameters.Articles;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Behaviours;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Query.Articles
{
    public class GetArticlesQuery : IRequest<PagedResponse<IReadOnlyList<ArticleModel>>>, ICacheableMediatrQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OrderBy { get; set; }
        public string SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
        public bool BypassCache { get; set; }
        public string CacheKey => $"Article";
        public TimeSpan? SlidingExpiration { get; set; }
    }
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, PagedResponse<IReadOnlyList<ArticleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _repository;
        public GetArticlesQueryHandler(IMapper mapper,
            IArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<ArticleModel>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ArticleParameter>(request);
            validFilter.SetSearchProps(new string[] { nameof(ArticleParameter.Code), nameof(ArticleParameter.Name) }.ToList());
            return await _repository.GetModelPagedReponseAsync<ArticleParameter, ArticleModel>(validFilter);
        }
    }
}
