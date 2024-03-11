using AutoMapper;
using Microsoft.Extensions.Logging;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxExportSyncDataService : IWfxExportSyncDataService
    {
        private readonly ILogger<WfxExportSyncDataService> _logger;
        private readonly IRequestClientService _requestClientService;
        private readonly IMapper _mapper;

        public WfxExportSyncDataService(
            ILogger<WfxExportSyncDataService> logger
            , IRequestClientService requestClientService
            , IMapper mapper
            )
        {
            _logger = logger;
            _requestClientService = requestClientService;
            _mapper = mapper;
        }

        public async Task<WfxExportSyncResponse> GetExportSyncsAsync(WfxExportSyncParameter parameter)
        {
            try
            {
                var rs = await _requestClientService.GetResponseAsync<GetWfxExportSyncRequest, GetWfxExportSyncResponse>(new GetWfxExportSyncRequest
                {
                    ColorCode = parameter.ColorCode,
                    WFXArticleCode = parameter.WFXArticleCode,
                    SizeCode = parameter.SizeCode,
                    ReceiptType = parameter.ReceiptType,
                    OrderType = parameter.OrderType,
                    OrderRefNum = parameter.OrderRefNum,
                    PageNumber = parameter.PageNumber,
                    PageSize = parameter.PageSize
                });
                if (rs == null) return default;
                return _mapper.Map<WfxExportSyncResponse>(rs.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
            return default;
        }


    }
}
