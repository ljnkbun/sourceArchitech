using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Application.Models.Wfxs;
using Shopfloor.Master.Application.Services.Wfxs;
using Shopfloor.Master.Application.Settings;

namespace Shopfloor.Master.Application.Jobs
{
    public class WfxMasterDataSyncJob : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WfxMasterDataSyncJob> _logger;
        private readonly IWfxMasterDataService _wfxMasterDataService;
        private readonly WfxApiSettings _wfxApiSettings;
        public WfxMasterDataSyncJob(IMediator mediator, ILogger<WfxMasterDataSyncJob> logger,
            IWfxMasterDataService wfxMasterDataService, IOptions<WfxApiSettings> setting)
        {
            _mediator = mediator;
            _logger = logger;
            _wfxMasterDataService = wfxMasterDataService;
            _wfxApiSettings = setting.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_wfxApiSettings.Enable == true)
                Task.Run(() => Start(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task Start(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SyncProductGroup();
                await SyncCurrency();
                await Task.Delay((int)TimeSpan.FromSeconds(_wfxApiSettings.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }
        async Task<List<WfxApiMasterData>> GetWFXData(string masterName)
        {
            var vrtn = await _wfxMasterDataService.GetMasterData(masterName);
            return vrtn?.ResponseData;
        }
        async Task SyncProductGroup()
        {
            try
            {
                var masterDatas = await GetWFXData("ProductGroup");
                _logger.LogInformation("Sync ProductGroup Data");
                if (masterDatas != null && masterDatas.Count > 0)
                    await _mediator.Send(new SyncProductGroupCommand() { Data = masterDatas });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error ProductGroupSyncJob: {ex.Message}");
            }
        }
        //TODO
        async Task SyncBuyer()
        {
            var mastName = "Buyer";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
        //TODO
        async Task SyncCurrency()
        {
            var mastName = "Currency";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
        //TODO
        async Task SyncUOM()
        {
            var mastName = "UOM";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
        //TODO
        async Task SyncCount()
        {
            var mastName = "COUNT";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
        //TODO
        async Task SyncConstruction()
        {
            var mastName = "Construction";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
        //TODO
        async Task SyncFabricContent()
        {
            var mastName = "FabricContent";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
        //TODO
        async Task SyncYarnComposition()
        {
            var mastName = "YarnComposition";
            try
            {
                var masterDatas = await GetWFXData(mastName);
                _logger.LogInformation($"Sync {mastName} Data");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error {mastName} Job: {ex.Message}");
            }
        }
    }
}
