using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Shopfloor.Cache.Services
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;
        public CachingService(IDistributedCache cache,
            ILogger<CachingService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task SetAsync<T>(string key, T data, TimeSpan slidingExpiration, CancellationToken cancellationToken = default)
        {
            var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration };
            var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(data));
            await _cache.SetAsync(key, serializedData, options, cancellationToken);
            _logger.LogInformation($"Added to Cache -> '{key}'.");
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            var cachedResponse = await _cache.GetAsync(key, cancellationToken);
            if (cachedResponse == null) return default;

            _logger.LogInformation($"Fetched from Cache -> '{key}'.");
            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(cachedResponse));
        }
    }
}
