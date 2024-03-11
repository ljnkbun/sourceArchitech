using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.Barcode.Application.Command.WfxGDIs;
using Shopfloor.Barcode.Application.Command.WfxPOArticles;
using Shopfloor.Barcode.Application.Services.Wfxs;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Extensions.Exceptions;

namespace Shopfloor.Barcode.Application.Jobs
{
    public class WfxGDIDataSyncJob : BackgroundService
    {
        private readonly ILogger<WfxGDIDataSyncJob> _logger;
        private readonly IWfxGDIServices _wfxArticleRequestService;
        private readonly IMediator _mediator;
        private readonly JobSettings _settings;
        public WfxGDIDataSyncJob(IServiceProvider serviceProvider,
            ILogger<WfxGDIDataSyncJob> logger,
            IOptions<JobSettings> setting)
        {
            var scope = serviceProvider.CreateScope();
            _wfxArticleRequestService = scope.ServiceProvider.GetRequiredService<IWfxGDIServices>(); 
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _logger = logger;
            _settings = setting.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_settings.GDI.Enable == true)
                Task.Run(() => Start(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task Start(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SyncArticle();
                await Task.Delay((int)TimeSpan.FromSeconds(_settings.GDI.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        public async Task SyncArticle()
        {
            try
            {
                var entites = await _wfxArticleRequestService.GetGDIsAsync();
                if (entites != null && entites.Any())
                {
                    await _mediator.Send(new SaveWfxGDIsSyncCommand() { Data = entites.ToList() });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error SyncWfxGDI: {Exception}", ex.FullMessage());
            }
        }

    }
}
