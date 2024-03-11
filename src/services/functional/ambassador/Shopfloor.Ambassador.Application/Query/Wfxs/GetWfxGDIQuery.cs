using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxGDIQuery : IRequest<PagedResponse<IReadOnlyList<WfxGDIData>>>, IAmbassadorQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<WFXAPIGDIMovementData> WFXAPIGDIMovementData { get; set; }
        public int RetryTimes { get; set; } = 3;

        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxGDI";

        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxGDIQueryHandler : IRequestHandler<GetWfxGDIQuery, PagedResponse<IReadOnlyList<WfxGDIData>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxGDIDataService _importGDIService;
        public GetWfxGDIQueryHandler(IMapper mapper,
            IWfxGDIDataService ImportGDIService)
        {
            _mapper = mapper;
            _importGDIService = ImportGDIService;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxGDIData>>> Handle(GetWfxGDIQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxGDIParameter>(request);
            var data = await _importGDIService.GetGDIsAsync(validFilter);
            return new(data, validFilter.PageNumber, validFilter.PageSize);
        }
    }

}
