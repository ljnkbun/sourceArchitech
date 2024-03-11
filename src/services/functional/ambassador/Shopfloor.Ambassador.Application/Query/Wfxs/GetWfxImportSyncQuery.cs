using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.EventBus.Models.Requests;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxImportSyncQuery : IRequest<IReadOnlyList<WfxImportSyncResponse>>, IAmbassadorQuery
    {
        public List<WfxImportSyncParameter> Parameters { get; set; }

        public int RetryTimes { get; set; } = 3;
        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxImportSync";
        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxImportSyncQueryHandler : IRequestHandler<GetWfxImportSyncQuery, IReadOnlyList<WfxImportSyncResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxImportSyncDataService _wfxImportSyncDataService;
        public GetWfxImportSyncQueryHandler(IMapper mapper,
            IWfxImportSyncDataService wfxImportSyncDataService)
        {
            _mapper = mapper;
            _wfxImportSyncDataService = wfxImportSyncDataService;
        }

        public async Task<IReadOnlyList<WfxImportSyncResponse>> Handle(GetWfxImportSyncQuery request, CancellationToken cancellationToken)
        {
            var parameters = _mapper.Map<List<GetWfxImportSyncParameter>>(request.Parameters);
            return await _wfxImportSyncDataService.GetImportSyncsAsync(parameters);
        }
    }

}
