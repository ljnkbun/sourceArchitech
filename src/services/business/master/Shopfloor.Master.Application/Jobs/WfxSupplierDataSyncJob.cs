using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Application.Command.Suppliers;
using Shopfloor.Master.Application.Settings;

namespace Shopfloor.Master.Application.Jobs
{
    public class WfxSupplierSyncJob : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WfxSupplierSyncJob> _logger;
        private readonly IRequestClientService _requestClientService;
        private readonly WfxSupplierApiSettings _wfxApiSettings;

        public WfxSupplierSyncJob(IServiceProvider serviceProvider, ILogger<WfxSupplierSyncJob> logger, IOptions<WfxSupplierApiSettings> setting)
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
                await SyncSupplier();
                await Task.Delay((int)TimeSpan.FromSeconds(_wfxApiSettings.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        private async Task SyncSupplier()
        {
            try
            {
                var data = await _requestClientService.GetResponseAsync<GetWfxMasterDataRequest, GetWfxMasterDataResponse>(new GetWfxMasterDataRequest
                {
                    MetaDataFor = "Supplier"
                });
                var suppliers = data?.Message?.Data;
                _logger.LogInformation($"Sync Supplier Data");
                if (suppliers is { Count: > 0 })
                    await _mediator.Send(new SyncSupplierCommand() { Data = suppliers });
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error SyncSupplier: {ex.FullMessage()}");
            }
        }
    }
}