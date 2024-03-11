using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Helpers;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxPOArticleDataService : IWfxPOArticleDataService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ILogger<WfxPOArticleDataService> _logger;
        public WfxPOArticleDataService(HttpClient httpClient,
            ILogger<WfxPOArticleDataService> logger)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
        }

        public async Task<List<WfxPOArticleData>> GetPOArticlesAsync(WfxPOArticleParameter parameter)
        {
            try
            {
                var content = await _restClientHelper.GetAsync(null, parameter.SearchDics);
                if (string.IsNullOrEmpty(content))
                {
                    _logger.LogError("Not Found Data!");
                    return default;
                }
                return JsonConvert.DeserializeObject<List<WfxPOArticleData>>(content); ;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

    }
}
