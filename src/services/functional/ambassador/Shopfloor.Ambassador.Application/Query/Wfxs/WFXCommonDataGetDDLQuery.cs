using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Application.Query.Wfxs
{
    public class WFXCommonDataGetDDLQuery : IRequest<Response<IReadOnlyList<WFXOperationLibrary>>>, IAmbassadorQuery
    {
        public string ObjectType { get; set; }
        public string PageParam { get; set; }
        public int RetryTimes { get; set; } = 3;
        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxPor";
        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromSeconds(3);
    }

    public class WFXCommonDataGetDDLQueryHandler : IRequestHandler<WFXCommonDataGetDDLQuery, Response<IReadOnlyList<WFXOperationLibrary>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxWebSharedService _wfxWebSharedService;
        public WFXCommonDataGetDDLQueryHandler(IMapper mapper
            , IWfxWebSharedService wfxWebSharedService)
        {
            _mapper = mapper;
            _wfxWebSharedService = wfxWebSharedService;
        }

        public async Task<Response<IReadOnlyList<WFXOperationLibrary>>> Handle(WFXCommonDataGetDDLQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WFXGetDDLParameter>(request);
            var data = await _wfxWebSharedService.WFXGetDDLOperationLibrary(validFilter);
            return new Response<IReadOnlyList<WFXOperationLibrary>>(data.responseData);
        }
    }
}
