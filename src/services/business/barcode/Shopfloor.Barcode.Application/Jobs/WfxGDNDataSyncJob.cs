using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.Barcode.Application.Command.SyncWFX;
using Shopfloor.Barcode.Application.Services.Wfxs;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Core.Extensions.Exceptions;

namespace Shopfloor.Barcode.Application.Jobs
{
    public class WfxGDNDataSyncJob : BackgroundService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<WfxGDNDataSyncJob> _logger;
        private readonly IWfxGDNServices _wfxArticleRequestService;
        private readonly JobSettings _settings;
        public WfxGDNDataSyncJob(IServiceProvider serviceProvider,
            ILogger<WfxGDNDataSyncJob> logger,
            IOptions<JobSettings> setting)
        {
            var scope = serviceProvider.CreateScope();
            _wfxArticleRequestService = scope.ServiceProvider.GetRequiredService<IWfxGDNServices>();
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _logger = logger;
            _settings = setting.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_settings.GDN.Enable == true)
                Task.Run(() => Start(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task Start(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SyncArticle();
                await Task.Delay((int)TimeSpan.FromSeconds(_settings.GDN.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        public async Task SyncArticle()
        {
            try
            {
                var entites = await _wfxArticleRequestService.GetGDNsAsync();
                if (entites != null && entites.Any())
                    await _mediator.Send(new WfxGDNDataSyncCommand() { Data = entites.ToList() });
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error SyncWfxGDN: {Exception}", ex.FullMessage());
            }
        }

    }
}
