using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxMasterDataService : IWfxMasterDataService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ILogger<WfxMasterDataService> _logger;
        public WfxMasterDataService(HttpClient httpClient,
            ILogger<WfxMasterDataService> logger)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
        }

        public async Task<List<WfxMasterData>> GetMasterDataAsync(WfxMasterDataParameter parameter)
        {
            var url = $"?MetaDataFor={parameter.MetaDataFor}";
            var content = await _restClientHelper.GetAsync(url);
            if (string.IsNullOrEmpty(content))
            {
                _logger.LogError("Not Found Data!");
                return default;
            }
            var response = JsonConvert.DeserializeObject<WfxMasterDataResponse<WfxMasterData>>(content);
            if (!string.IsNullOrEmpty(response.ErrorMsg)) _logger.LogError(response.ErrorMsg);
            return response.ResponseData;
        }
    }
}
