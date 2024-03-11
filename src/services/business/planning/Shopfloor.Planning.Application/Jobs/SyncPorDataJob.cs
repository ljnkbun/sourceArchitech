using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.Planning.Application.Command.PORs;
using Shopfloor.Planning.Application.Settings;

namespace Shopfloor.Planning.Application.Jobs
{
    public class SyncPorDataJob : BackgroundService
    {
        #region constant
        const string FileConfigWFX = "syncPor.txt";
        const string PathRoot = "WfxPorSync";
        const string Yarns = "Yarns";
        const string Textiles = "Textiles/Fabric";
        const string Trims = "Trims";
        const string Apparel = "Apparel";
       
        #endregion

        private readonly IMediator _mediator;
        private readonly JobPorSettings _settings;
        private readonly ILogger<SyncPorDataJob> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SyncPorDataJob(IServiceProvider serviceProvider
            , IOptions<JobPorSettings>  settings
            , ILogger<SyncPorDataJob> logger
            , IWebHostEnvironment webHostEnvironment)
        {
            var scope = serviceProvider.CreateScope();
            _logger = logger;
            _settings = settings.Value;
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _webHostEnvironment = webHostEnvironment;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_settings.PorJob.Enable == true)
                Task.Run(() => Start(stoppingToken), stoppingToken);
            return Task.CompletedTask;
        }

        private async Task Start(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SyncPors();
                await Task.Delay((int)TimeSpan.FromSeconds(_settings.PorJob.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }

        public async Task SyncPors()
        {
            try
            {
                var syncCf = GetSyncConfigs();
                if (syncCf == null || syncCf.Count == 0)
                    return;

                //Yarns
                var cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Yarns);
                await DoSyncPor(cf);
                //Textiles
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Textiles);
                await DoSyncPor(cf);
                //Trims
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Trims);
                await DoSyncPor(cf);
                //Apparel
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Apparel);
                await DoSyncPor(cf);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error SyncPors: {ex.FullMessage()}");
            }
        }
    
        private async Task DoSyncPor(PorJob cf)
        {
            if (cf == null) return;

            var syncPorCommand = new SyncPorDataJobCommand()
            {
                category = cf.Category,
                ocNo = cf.OcNo,
                lastDays = cf.LastDays,
            };
            var response = await _mediator.Send(syncPorCommand);

            if (response.Succeeded)
                _logger.LogInformation($"Success SyncPors");
            else
                _logger.LogInformation($"Failure SyncPors");
        }

        private List<PorJob> GetSyncConfigs()
        {
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, PathRoot, FileConfigWFX);
            if (!File.Exists(fullPath))
                return new List<PorJob>
                    {
                        new()
                        {
                            Category = "Yarns",
                            LastDays = _settings.PorJob.LastDays,
                            Enable = true
                        },
                        new()
                        {
                            Category = "Textiles/Fabric",
                            LastDays = _settings.PorJob.LastDays,
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Trims",
                            LastDays = _settings.PorJob.LastDays,
                            Enable = true,
                        },
                        new()
                        {
                            Category = "Apparel",
                            LastDays = _settings.PorJob.LastDays,
                            Enable = true,
                        }
                    };
            var json = File.ReadAllText(fullPath);
            return JsonConvert.DeserializeObject<List<PorJob>>(json);
        }
    }
}
