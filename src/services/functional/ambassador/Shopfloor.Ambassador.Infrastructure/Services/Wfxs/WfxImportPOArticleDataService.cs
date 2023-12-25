using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            var content = await _restClientHelper.GetAsync(null, parameter.SearchDics);
            if (string.IsNullOrEmpty(content))
            {
                _logger.LogError("Not Found Data!");
                return default;
            }
            var rs = JsonConvert.DeserializeObject<WfxPOArticleReponseData>(content);
            if (!string.IsNullOrEmpty(rs.ErrorMsg))
            {
                _logger.LogError(rs.ErrorMsg);
                return default;
            }
            return rs.ResponseData.SelectMany(x => x.OrderData).ToList();
        }

    }
}
