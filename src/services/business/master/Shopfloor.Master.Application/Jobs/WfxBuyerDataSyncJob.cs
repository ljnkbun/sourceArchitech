using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Application.Command.Buyers;
using Shopfloor.Master.Application.Settings;

namespace Shopfloor.Master.Application.Jobs
{
    public class WfxBuyerSyncJob : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WfxBuyerSyncJob> _logger;
        private readonly WfxBuyerApiSettings _wfxApiSettings;
        private readonly IRequestClientService _requestClientService;

        public WfxBuyerSyncJob(IServiceProvider serviceProvider, ILogger<WfxBuyerSyncJob> logger, IOptions<WfxBuyerApiSettings> setting)
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
                await SyncBuyer();
                await Task.Delay((int)TimeSpan.FromSeconds(_wfxApiSettings.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        private async Task SyncBuyer()
        {
            try
            {
                var data = await _requestClientService
                    .GetResponseAsync<GetWfxMasterDataRequest, GetWfxMasterDataResponse>(new GetWfxMasterDataRequest
                    {
                        MetaDataFor = "Buyer"
                    });
                var buyers = data?.Message?.Data;
                _logger.LogInformation($"Sync Buyer Data");
                if (buyers is { Count: > 0 })
                    await _mediator.Send(new SyncBuyerCommand() { Data = buyers });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error SyncBuyer: {ex.FullMessage()}");
            }
        }
    }
}