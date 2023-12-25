using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shopfloor.Barcode.Application.Services.Wfxs;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Extensions.Exceptions;

namespace Shopfloor.Barcode.Application.Jobs
{
    public class WfxPOArticleDataSyncJob : BackgroundService
    {
        private readonly ILogger<WfxPOArticleDataSyncJob> _logger;
        private readonly IWfxPOArticleServices _wfxArticleRequestService;
        private readonly IWfxPOArticleRepository _articleRepository;
        private readonly JobSettings _settings;
        public WfxPOArticleDataSyncJob(IServiceProvider serviceProvider,
            ILogger<WfxPOArticleDataSyncJob> logger,
            IOptions<JobSettings> setting)
        {
            var scope = serviceProvider.CreateScope();
            _wfxArticleRequestService = scope.ServiceProvider.GetRequiredService<IWfxPOArticleServices>();
            _articleRepository = scope.ServiceProvider.GetRequiredService<IWfxPOArticleRepository>();
            _logger = logger;
            _settings = setting.Value;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_settings.POArticle.Enable == true)
                Task.Run(() => Start(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task Start(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SyncArticle();
                await Task.Delay((int)TimeSpan.FromSeconds(_settings.POArticle.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        public async Task SyncArticle()
        {
            try
            {
                var entites = await _wfxArticleRequestService.GetPOArticlesAsync();
                if (entites.Any())
                {
                    SaveWfxPOArticleSync(entites);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error SyncWfxPOArticle: {ex.FullMessage()}");
            }
        }

        private async void SaveWfxPOArticleSync(IReadOnlyList<WfxPOArticle> entites)
        {
            await _articleRepository.SaveWfxPOArticleSync(entites.ToList());
        }

    }
}
