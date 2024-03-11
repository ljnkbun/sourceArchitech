using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopfloor.Core.Extensions.Exceptions;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;
using Shopfloor.Master.Application.Command.Articles;
using Shopfloor.Master.Application.Models.Wfxs;
using Shopfloor.Master.Application.Settings;
using System.Globalization;

namespace Shopfloor.Master.Application.Jobs
{
    public class WfxArticleDataSyncJob : BackgroundService
    {
        #region constant
        const string FileConfigWFX = "syncaticle.txt";
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
        private readonly ILogger<WfxArticleDataSyncJob> _logger;
        private readonly IRequestClientService _requestClientService;
        private readonly WfxArticleApiSettings _settings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WfxArticleDataSyncJob(IServiceProvider serviceProvider,
            ILogger<WfxArticleDataSyncJob> logger,
            IOptions<WfxArticleApiSettings> setting, IWebHostEnvironment webHostEnvironment)
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
                await SyncArticle();
                await Task.Delay((int)TimeSpan.FromSeconds(_settings.IntervalSecond).TotalMilliseconds, stoppingToken);
            }
        }
        public async Task SyncArticle()
        {
            try
            {
                var syncCf = GetSyncConfigs();
                if (syncCf == null || syncCf.Count == 0)
                    return;
                //Yarns
                var cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Yarns);
                await DoSyncArticle(cf);
                //Textiles
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Textiles);
                await DoSyncArticle(cf);
                //Trims
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Trims);
                await DoSyncArticle(cf);
                //Apparel
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Apparel);
                await DoSyncArticle(cf);
                //Fiber
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Fiber);
                await DoSyncArticle(cf);
                //FixedAsset
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == FixedAsset);
                await DoSyncArticle(cf);
                //Miscellaneous
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Miscellaneous);
                await DoSyncArticle(cf);
                //Services
                cf = syncCf.Where(x => x.Enable == true).FirstOrDefault(x => x.Category == Services);
                await DoSyncArticle(cf);

                SaveSyncConfigs(syncCf);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error SyncArticle: {ex.FullMessage()}");
            }
        }

        private async Task DoSyncArticle(ArticleSyncConfig cf)
        {
            if (cf == null) return;
            var createdFrom = cf.CreatedFrom;
            var modifiedFrom = cf.ModifiedFrom;
            var dataSearch = new Dictionary<string, string>
                    {
                        { nameof(cf.Category), cf.Category }
                    };
            if (createdFrom != null)
                dataSearch.Add(nameof(cf.CreatedFrom), createdFrom.Value.ToString("yyyy-MM-dd"));
            var dataWFXService = await _requestClientService.GetResponseAsync<GetWfxArticleRequest, GetWfxArticleResponse>(new GetWfxArticleRequest
            {
                SearchDics = dataSearch
            });
            var dataWFX = dataWFXService?.Message?.Data;
            _logger.LogInformation($"Find {cf.Category} {dataWFX?.Count} data {cf.Category} {createdFrom}");
            var dataWFXModified = new List<WfxArticleDto>();
            if (modifiedFrom != null)
            {
                if (dataSearch.ContainsKey(nameof(cf.CreatedFrom)))
                    dataSearch.Remove(nameof(cf.CreatedFrom));
                dataSearch.Add(nameof(cf.ModifiedFrom), modifiedFrom.Value.ToString("yyyy-MM-dd"));
                var dataWFXModifiedService = await _requestClientService.GetResponseAsync<GetWfxArticleRequest, GetWfxArticleResponse>(new GetWfxArticleRequest
                {
                    SearchDics = dataSearch
                });
                dataWFXModified = dataWFXModifiedService?.Message?.Data;
                _logger.LogInformation($"Find {cf.Category} {dataWFXModified?.Count} data {cf.Category} {modifiedFrom}");

            }
            dataWFX.AddRange(dataWFXModified.Where(x => !dataWFX.Any(y => y.ArticleID == x.ArticleID)));
            if (dataWFX != null && dataWFX.Count > 0)
            {
                await _mediator.Send(new SyncArticleCommand() { Data = dataWFX, Category = cf.Category });
                cf.CreatedFrom = GetMaxCreatedDate(dataWFX);
                cf.ModifiedFrom = GetMaxModifiedDate(dataWFX);
            }
        }

        private DateTime? ToDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse(date, new DateTimeFormatInfo { ShortDatePattern = "dd MM yyyy" }, out result))
                return result;
            return null;
        }
        private DateTime? GetMaxModifiedDate(List<WfxArticleDto> dataWFX)
        {
            return dataWFX.Max(x => ToDate(x.ModifiedOnDate));
        }
        private DateTime? GetMaxCreatedDate(List<WfxArticleDto> dataWFX)
        {
            return dataWFX.Max(x => ToDate(x.CreatedOn));
        }
        private List<ArticleSyncConfig> GetSyncConfigs()
        {
            var fullPath = Path.Combine(_webHostEnvironment.ContentRootPath, PathRoot, FileConfigWFX);
            if (!File.Exists(fullPath))
                return new List<ArticleSyncConfig>
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
            return JsonConvert.DeserializeObject<List<ArticleSyncConfig>>(json);
        }
        private void SaveSyncConfigs(List<ArticleSyncConfig> configs)
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
