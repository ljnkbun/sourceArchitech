using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Core.Helpers;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Infrastructure.Services.Wfxs
{
    public class WfxPorDataService : IWfxPorDataService
    {
        private readonly ILogger<WfxPorDataService> _logger;
        private readonly IRestClientHelper _restClientHelper;

        public WfxPorDataService(ILogger<WfxPorDataService> logger
            , HttpClient httpClient)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
        }

        public async Task<List<GetWfxPorResponse>> GetWfxPorsAsync(WfxPorParameter parameter)
        {
            try
            {
                var rs = new Dictionary<string, string>
                {
                    {"Category", parameter.Category },
                    {"GETLastDays", parameter.GETLastDays },
                    {"OCNO", parameter.OCNO}
                };

                var content = await _restClientHelper.GetAsync(null, rs);
                if (string.IsNullOrEmpty(content))
                {
                    _logger.LogError("Not Found Data!");
                    return default;
                }

                return JsonConvert.DeserializeObject<List<GetWfxPorResponse>>(content);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }
    }
}
