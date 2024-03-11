using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxExportSyncQuery : IRequest<PagedResponse<IReadOnlyList<WFXAPIGeneratePLTData>>>, IAmbassadorQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderRefNum { get; set; }
        public string WFXArticleCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string OrderType { get; set; }
        public string ReceiptType { get; set; }


        public int RetryTimes { get; set; } = 3;

        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxExportSync";

        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxExportSyncQueryHandler : IRequestHandler<GetWfxExportSyncQuery, PagedResponse<IReadOnlyList<WFXAPIGeneratePLTData>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxExportSyncDataService _wfxExportSyncDataService;
        public GetWfxExportSyncQueryHandler(IMapper mapper,
            IWfxExportSyncDataService wfxExportSyncDataService)
        {
            _mapper = mapper;
            _wfxExportSyncDataService = wfxExportSyncDataService;
        }

        public async Task<PagedResponse<IReadOnlyList<WFXAPIGeneratePLTData>>> Handle(GetWfxExportSyncQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxExportSyncParameter>(request);
            var data = await _wfxExportSyncDataService.GetExportSyncsAsync(validFilter);
            return new(data.Data, validFilter.PageNumber, validFilter.PageSize);
        }
    }

}
