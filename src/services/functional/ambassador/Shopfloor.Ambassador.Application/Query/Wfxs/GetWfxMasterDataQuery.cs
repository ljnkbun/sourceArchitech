using AutoMapper;
using MediatR;
using Shopfloor.Ambassador.Application.Behaviours;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Application.Query
{
    public class GetWfxMasterDataQuery : IRequest<PagedResponse<IReadOnlyList<WfxMasterData>>>, IAmbassadorQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string MetaDataFor { get; set; }

        public int RetryTimes { get; set; } = 3;
        public string CircuitBreakerCacheKey => "CircuitBreaker_WfxMasterData";
        public TimeSpan TimeoutExpiration { get; set; } = TimeSpan.FromHours(1);
    }
    public class GetWfxMasterDataQueryHandler : IRequestHandler<GetWfxMasterDataQuery, PagedResponse<IReadOnlyList<WfxMasterData>>>
    {
        private readonly IMapper _mapper;
        private readonly IWfxMasterDataService _masterDataService;
        public GetWfxMasterDataQueryHandler(IMapper mapper,
            IWfxMasterDataService masterDataService)
        {
            _mapper = mapper;
            _masterDataService = masterDataService;
        }

        public async Task<PagedResponse<IReadOnlyList<WfxMasterData>>> Handle(GetWfxMasterDataQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<WfxMasterDataParameter>(request);
            var data = await _masterDataService.GetMasterDataAsync(validFilter);
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
