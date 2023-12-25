using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxPOArticleQuery : IRequest<PagedResponse<IReadOnlyList<WfxPOArticleData>>>, IAmbassadorQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> SearchDics { get; set; }
        public int RetryTimes { get; set; } = 3;

        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxPOArticle";

        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxPOArticleQueryHandler : IRequestHandler<GetWfxPOArticleQuery, PagedResponse<IReadOnlyList<WfxPOArticleData>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxPOArticleDataService _importPOArticleService;
        public GetWfxPOArticleQueryHandler(IMapper mapper,
            IWfxPOArticleDataService ImportPOArticleService)
        {
            _mapper = mapper;
            _importPOArticleService = ImportPOArticleService;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxPOArticleData>>> Handle(GetWfxPOArticleQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxPOArticleParameter>(request);
            var data = await _importPOArticleService.GetPOArticlesAsync(validFilter);
            return new(data, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
