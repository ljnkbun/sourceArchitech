using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Application.Settings;

namespace Shopfloor.Master.Application.Jobs
{
    public class WfxMasterDataSyncJob : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WfxMasterDataSyncJob> _logger;
        private readonly IRequestClientService _requestClientService;
        private readonly WfxApiSettings _wfxApiSettings;
        public WfxMasterDataSyncJob(IServiceProvider serviceProvider, ILogger<WfxMasterDataSyncJob> logger, IOptions<WfxApiSettings> setting)
        {
            var scope = serviceProvider.CreateScope();
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _requestClientService = scope.ServiceProvider.GetRequiredService<IRequestClientService>();
            _logger = logger;
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
                await Task.Delay((int)TimeSpan.FromSeconds(_wfxApiSettings.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }
        async Task SyncProductGroup()
        {
                 var data = await _requestClientService.GetResponseAsync<GetWfxMasterDataRequest, GetWfxMasterDataResponse>(new GetWfxMasterDataRequest
                {
                    MetaDataFor = "ProductGroup"
                });
                var masterDatas = data?.Message?.Data;
                _logger.LogInformation("Sync ProductGroup Data");
                if (masterDatas != null && masterDatas.Count > 0)
                    await _mediator.Send(new SyncProductGroupCommand() { Data = masterDatas });
        }
    }
}
