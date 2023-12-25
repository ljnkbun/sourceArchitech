using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Helpers;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxArticleService : IWfxArticleService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ILogger<WfxArticleService> _logger;
        public WfxArticleService(HttpClient httpClient,
            ILogger<WfxArticleService> logger)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
        }

        public async Task<List<WfxArticle>> GetArticlesAsync(WfxArticleParameter parameter)
        {
            var content = await _restClientHelper.GetAsync(null, parameter.SearchDics);
            if (string.IsNullOrEmpty(content))
            {
                _logger.LogError("Not Found Data!");
                return default;
            }
            if (!content.Contains("ArticleID"))
            {
                _logger.LogError("Content do not contains ArticleID!");
                return default;

            }
            return JsonConvert.DeserializeObject<List<WfxArticle>>(content);
        }
    }
}
