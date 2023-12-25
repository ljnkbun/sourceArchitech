using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxArticleQuery : IRequest<PagedResponse<IReadOnlyList<WfxArticle>>>, IAmbassadorQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> SearchDics { get; set; }

        public int RetryTimes { get; set; } = 3;
        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxArticle";
        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxArticleQueryHandler : IRequestHandler<GetWfxArticleQuery, PagedResponse<IReadOnlyList<WfxArticle>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxArticleService _articleService;
        public GetWfxArticleQueryHandler(IMapper mapper,
            IWfxArticleService articleService)
        {
            _mapper = mapper;
            _articleService = articleService;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxArticle>>> Handle(GetWfxArticleQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxArticleParameter>(request);
            var data = await _articleService.GetArticlesAsync(validFilter);
            return new()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = data.Count,
                Succeeded = true,
                Data = data
            };
        }
    }
}
