using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Settings;
using System.Text;

namespace Shopfloor.Core.Behaviours
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : ICacheableMediatrQuery
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        private readonly CacheSettings _settings;
        public CachingBehavior(IDistributedCache cache, ILogger<TResponse> logger, IOptions<CacheSettings> settings)
        {
            _cache = cache;
            _logger = logger;
            _settings = settings.Value;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            if (request.BypassCache) return await next();
            var uniqueKey = GetUniqueKey(request);
            async Task<TResponse> GetResponseAndAddToCache()
            {
                response = await next();
                var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromSeconds(_settings.SlidingExpiration) : request.SlidingExpiration;
                var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
                var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await _cache.SetAsync(uniqueKey, serializedData, options, cancellationToken);
                return response;
            }
            var cachedResponse = await _cache.GetAsync(uniqueKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
                _logger.LogInformation($"Fetched from Cache -> '{uniqueKey}'.");
            }
            else
            {
                response = await GetResponseAndAddToCache();
                _logger.LogInformation($"Added to Cache -> '{uniqueKey}'.");
            }
            return response;
        }

        private static string GetUniqueKey(TRequest request)
        {
            var dics = request.AsDictionary();
            string uniqueKey = string.Join('_', dics.Where(x => x.Value != null 
                                            && x.Key != "CacheKey"
                                            && x.Key != "BypassCache" 
                                            && x.Key != "SlidingExpiration")
                .Select(x => x.Value));
            return $"{request.CacheKey}_{uniqueKey}";
        }
    }
}
