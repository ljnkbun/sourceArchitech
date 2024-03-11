using Microsoft.Extensions.Logging;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Core.Helpers;
using System.Text.Json;

namespace Shopfloor.Ambassador.Infrastructure.Services
{
    public class WfxGDIDataService : IWfxGDIDataService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly ILogger<WfxGDIDataService> _logger;
        public WfxGDIDataService(HttpClient httpClient,
            ILogger<WfxGDIDataService> logger)
        {
            _restClientHelper = new RestClientHelper(httpClient);
            _logger = logger;
        }

        public async Task<List<WfxGDIData>> GetGDIsAsync(WfxGDIParameter parameter)
        {
            try
            {
                var content = await _restClientHelper.PostAsync(null, parameter);
                if (string.IsNullOrEmpty(content))
                {
                    _logger.LogError("Not Found Data!");
                    return default;
                }
                var rs = JsonSerializer.Deserialize<WfxGDIReponseData>(content);
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
                    x.OrderData.ForEach(child =>
                    {
                        child.OrderCreationDate = x.gDICreationDate;
                        child.GDINum = x.GDINum;

                    });
                    return x.OrderData;
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
