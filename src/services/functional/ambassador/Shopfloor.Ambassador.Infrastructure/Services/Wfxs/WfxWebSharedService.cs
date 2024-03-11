using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Ambassador.Application.Settings;
using Shopfloor.Core.Helpers;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxWebSharedService : IWfxWebSharedService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ILogger<IWfxWebSharedService> _logger;
        private readonly WFXWebSharedAPISetting _webSharedAPISetting;
        public WfxWebSharedService(HttpClient httpClient,
            ILogger<IWfxWebSharedService> logger, IOptions<WFXWebSharedAPISetting> setting)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
            _webSharedAPISetting = setting.Value;
        }
        private string GetEndPoint(string endpoint, string parameter)
        {
            return $"{endpoint}?APIKey={_webSharedAPISetting.APIKey}&SecretKey={_webSharedAPISetting.SecretKey}&{parameter}";
        }
        public async Task<WFXWebSharedResponse<List<WfxWebSharedDetailResponse>>> WFXProductGroupSubCategorySync(WFXProductGroupSubCategoryParameter parameter)
        {
            var endPoint = GetEndPoint("WFXProductGroupSubCategory/GetJSONData", $"Category={parameter.Category}");
            var content = await _restClientHelper.GetAsync(endPoint);
            if (string.IsNullOrEmpty(content))
            {
                _logger.LogError("Not Found Data!");
                return default;
            }
            return JsonConvert.DeserializeObject<WFXWebSharedResponse<List<WfxWebSharedDetailResponse>>>(content);
        }

        public async Task<WFXWebSharedResponse<List<WFXOperationLibrary>>> WFXGetDDLOperationLibrary(WFXGetDDLParameter parameter)
        {
            try
            {
                var endPoint = GetEndPoint("WFXCommonData/GetDDL", $"ObjectType={parameter.ObjectType}&pageParams={parameter.PageParam}");
                var content = await _restClientHelper.GetAsync(endPoint);
                if (string.IsNullOrEmpty(content))
                {
                    _logger.LogError("Not Found Data!");
                    return default;
                }
                return JsonConvert.DeserializeObject<WFXWebSharedResponse<List<WFXOperationLibrary>>>(content);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

        }
    }
}
