using Microsoft.Extensions.Logging;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Application.Services.Wfxs;

namespace Shopfloor.Master.Infrastructure.Services.Wfxs
{
    public class WfxArticleRequestService : IWfxArticleRequestService
    {
        private readonly IRequestClientService _requestClientService;
        private readonly ILogger<WfxArticleRequestService> _logger;
        public WfxArticleRequestService(IRequestClientService requestClientService,
            ILogger<WfxArticleRequestService> logger)
        {
            _requestClientService = requestClientService;
            _logger = logger;
        }

        public async Task<List<WfxArticleDto>> SearchArticle(Dictionary<string, string> dataSearch)
        {
            try
            {
                var data = await _requestClientService.GetResponseAsync<GetWfxArticleRequest, GetWfxArticleResponse>(new GetWfxArticleRequest
                {
                    SearchDics = dataSearch
                });
                return data?.Message?.Data;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Error SearchArticle: {e.FullMessage()}");
                return null;
            }
        }
    }
}
