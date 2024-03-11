using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query.Wfxs
{
    public class GetWfxWebSharedDataQuery : IRequest<Response<IReadOnlyList<WfxWebSharedDetailResponse>>>, IAmbassadorQuery
    {
        public string Category { get; set; }
        public int RetryTimes { get; set; } = 3;

        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxWebShared";

        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }

    public class GetWfxWebSharedDataQueryHandler : IRequestHandler<GetWfxWebSharedDataQuery, Response<IReadOnlyList<WfxWebSharedDetailResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxWebSharedService _wfxWebSharedService;

        public GetWfxWebSharedDataQueryHandler(IMapper mapper
            , IWfxWebSharedService wfxWebSharedService)
        {
            _mapper = mapper;
            _wfxWebSharedService = wfxWebSharedService;
        }

        public async Task<Response<IReadOnlyList<WfxWebSharedDetailResponse>>> Handle(GetWfxWebSharedDataQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WFXProductGroupSubCategoryParameter>(request);
            var data = await _wfxWebSharedService.WFXProductGroupSubCategorySync(validFilter);
            return new Response<IReadOnlyList<WfxWebSharedDetailResponse>>(data.responseData);
        }
    }
}
