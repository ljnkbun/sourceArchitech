using AutoMapper;
using Microsoft.Extensions.Logging;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxImportSyncDataService : IWfxImportSyncDataService
    {
        private readonly ILogger<WfxImportSyncDataService> _logger;
        private readonly IRequestClientService _requestClientService;
        private readonly IMapper _mapper;

        public WfxImportSyncDataService(
            ILogger<WfxImportSyncDataService> logger
            , IRequestClientService requestClientService
            , IMapper mapper
            )
        {
            _logger = logger;
            _requestClientService = requestClientService;
            _mapper = mapper;
        }

        public async Task<List<WfxImportSyncResponse>> GetImportSyncsAsync(List<GetWfxImportSyncParameter> parameters)
        {
            try
            {
                var rs = await _requestClientService.GetResponseAsync<GetWfxImportSyncRequest, GetWfxImportSyncResponse>(new GetWfxImportSyncRequest
                {
                   Parameters = parameters
                });
                if (rs == null) return default;
                return _mapper.Map<List<WfxImportSyncResponse>>(rs.Message.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
            return default;
        }


    }
}
