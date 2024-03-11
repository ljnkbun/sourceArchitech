using MassTransit.Mediator;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Application.Models.Wfxs;
using Shopfloor.Master.Application.Settings;

namespace Shopfloor.Master.Application.Jobs
{
    public class WfxWebSharedDataSyncJob : BackgroundService
    {
        #region constant
        const string FileConfigWFX = "syncwebshared.txt";
        const string PathRoot = "WFXSync";
        const string Yarns = "Yarns";
        const string Textiles = "Textiles/Fabric";
        const string Trims = "Trims";
        const string Apparel = "Apparel";
        const string Fiber = "Fiber";
        const string FixedAsset = "Fixed Asset";
        const string Miscellaneous = "Miscellaneous";
        const string Services = "Services";
        #endregion

        private readonly IMediator _mediator;
        private readonly ILogger<WfxWebSharedDataSyncJob> _logger;
        private readonly IRequestClientService _requestClientService;
        private readonly WfxWebShareApiSettings _settings;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public WfxWebSharedDataSyncJob(IServiceProvider serviceProvider
            , ILogger<WfxWebSharedDataSyncJob> logger
            , IOptions<WfxWebShareApiSettings> setting
            , IWebHostEnvironment webHostEnvironment)
        {
            var scope = serviceProvider.CreateScope();
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _requestClientService = scope.ServiceProvider.GetRequiredService<IRequestClientService>();
            _logger = logger;
            _settings = setting.Value;
            _webHostEnvironment = webHostEnvironment;
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_settings.Enable == true)
                Task.Run(() => Start(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task Start(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay((int)TimeSpan.FromSeconds(_settings.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        public async Task SyncWebShared()
        {
            try
            {
                var syncCf = GetSyncConfigs();
                if (syncCf == null || syncCf.Count == 0)
                    return;
                //Yarns
                var cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Yarns);
                await DoSyncWebShared(cf);
                //Textiles
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Textiles);
                await DoSyncWebShared(cf);
                //Trims
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Trims);
                await DoSyncWebShared(cf);
                //Apparel
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Apparel);
                await DoSyncWebShared(cf);
                //Fiber
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Fiber);
                await DoSyncWebShared(cf);
                //FixedAsset
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == FixedAsset);
                await DoSyncWebShared(cf);
                //Miscellaneous
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Miscellaneous);
                await DoSyncWebShared(cf);
                //Services
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Services);
                await DoSyncWebShared(cf);

                SaveSyncConfigs(syncCf);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error SyncArticle: {ex.FullMessage()}");
            }
        }

        private async Task DoSyncWebShared(WebSharedSyncConfig config)
        {

        }

        private List<WebSharedSyncConfig> GetSyncConfigs()
        {
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, PathRoot, FileConfigWFX);
            if (!File.Exists(fullPath))
                return new List<WebSharedSyncConfig>
                    {
                        new()
                        {
                            Category = "Yarns",
                            Enable = true
                        },
                        new()
                        {
                            Category = "Textiles/Fabric",
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Trims",
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Apparel",
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Fiber",
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Fixed Asset",
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Miscellaneous",
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Services",
                            Enable = true,
                        }
                    };
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<List<WebSharedSyncConfig>>(json);
        }

        private void SaveSyncConfigs(List<WebSharedSyncConfig> configs)
        {
            if (configs == null || configs.Count == 0) return;
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, PathRoot);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var fullPath = Path.Combine(path, FileConfigWFX);
            var json = JsonConvert.SerializeObject(configs, Formatting.Indented);
            File.WriteAllText(fullPath, json);
        }
    }
}
