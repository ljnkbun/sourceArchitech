using Microsoft.Extensions.Logging;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Helpers;
using System.Text.Json;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxGDNDataService : IWfxGDNDataService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ILogger<WfxGDNDataService> _logger;
        public WfxGDNDataService(HttpClient httpClient,
            ILogger<WfxGDNDataService> logger)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
        }

        public async Task<List<WfxGDNData>> GetGDNsAsync(WfxGDNParameter parameter)
        {
            try
            {
                var content = await _restClientHelper.GetAsync(null, parameter);
                if (string.IsNullOrEmpty(content))
                {
                    _logger.LogError("Not Found Data!");
                    return default;
                }
                var rs = JsonSerializer.Deserialize<WfxGDNReponseData>(content);
                if (!string.IsNullOrEmpty(rs.ErrorMsg))
                {
                    if (rs.ErrorMsg != "[]")
                    {
                        _logger.LogError(rs.ErrorMsg);
                        return default;
                    }
                }
                return rs.ResponseData.SelectMany(x =>
                {
                    foreach (var child in x.ListRoll)
                    {
                        child.GDNNum = x.GDNNum;
                        child.GDNType = x.GDNType;
                        child.OrderRefNum = x.OrderRefNum;
                        child.GDNCreationDate = x.gDNCreationDate;
                    }
                    return x.ListRoll;
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
            return default;
        }


    }
}
