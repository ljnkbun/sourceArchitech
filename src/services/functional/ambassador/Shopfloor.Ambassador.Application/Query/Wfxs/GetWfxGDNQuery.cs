using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxGDNQuery : IRequest<PagedResponse<IReadOnlyList<WfxGDNData>>>, IAmbassadorQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<WFXAPIGDNMovementData> WFXAPIGDNMovementData { get; set; }
        public int RetryTimes { get; set; } = 3;

        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxGDN";

        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxGDNQueryHandler : IRequestHandler<GetWfxGDNQuery, PagedResponse<IReadOnlyList<WfxGDNData>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDNDataService _importGDNService;
        public GetWfxGDNQueryHandler(IMapper mapper,
            IWfxGDNDataService ImportGDNService)
        {
            _mapper = mapper;
            _importGDNService = ImportGDNService;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxGDNData>>> Handle(GetWfxGDNQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxGDNParameter>(request);
            var data = await _importGDNService.GetGDNsAsync(validFilter);
            return new(data, validFilter.PageNumber, validFilter.PageSize);
        }
    }

}
