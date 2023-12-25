using Shopfloor.Core.Helpers;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Wfxs;
using Shopfloor.Master.Application.Services.Wfxs;

namespace Shopfloor.Master.Infrastructure.Services.Wfxs
{
    public class WfxMasterDataService : IWfxMasterDataService
    {
        private readonly IRestClientHelper _restClientHelper;
        public WfxMasterDataService(HttpClient httpClient)
        {
            _restClientHelper = new RestClientHelper(httpClient);
        }

        public async Task<WfxMasterDataResponse<WfxApiMasterData>> GetMasterData(string masterName)
        {
            var url = FullUrl(masterName);
            var content = await _restClientHelper.GetAsync(url);
            if (string.IsNullOrEmpty(content)) return default;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<WfxMasterDataResponse<WfxApiMasterData>>(content);
        }
        string FullUrl(string masterName)
        {
            return $"?MetaDataFor={masterName}";
        }
    }
}
