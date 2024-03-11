using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Application.Query.Wfxs
{
    public class GetWfxPorDataQuery : IRequest<Response<IReadOnlyList<GetWfxPorResponse>>>, IAmbassadorQuery
    {
        public string Category { get; set; }
        public string OcNo { get; set; }
        public string GETLastDays { get; set; }
        public int RetryTimes { get; set; } = 3;

        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxPor";

        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }

    public class GetWfxPorDataQueryHandler : IRequestHandler<GetWfxPorDataQuery, Response<IReadOnlyList<GetWfxPorResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxPorDataService _wfxPorDataService;
        public GetWfxPorDataQueryHandler(IMapper mapper
            , IWfxPorDataService wfxPorDataService)
        {
            _mapper = mapper;
            _wfxPorDataService = wfxPorDataService;
        }

        public async Task<Response<IReadOnlyList<GetWfxPorResponse>>> Handle(GetWfxPorDataQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxPorParameter>(request);
            var data = await _wfxPorDataService.GetWfxPorsAsync(validFilter);
            return new Response<IReadOnlyList<GetWfxPorResponse>>(data);
        }
    }
}
