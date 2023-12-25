using MediatR;
using Microsoft.Extensions.Logging;
using Shopfloor.Ambassador.Application.Definations;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Cache.Services;
using Shopfloor.Core.Exceptions;

namespace Shopfloor.Ambassador.Application.Behaviours
{
    public class AmbassadorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IAmbassadorQuery
    {
        private readonly ILogger _logger;
        private readonly ICachingService _cachingService;
        public AmbassadorBehavior(ILogger<TResponse> logger,
            ICachingService cachingService)
        {
            _logger = logger;
            _cachingService = cachingService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var circuitBreaker = await _cachingService.GetAsync<CircuitBreaker>(request.CircuitBreakerCacheKey, cancellationToken)
                ?? new CircuitBreaker();

            if (circuitBreaker.Status == CircuitBreakerStatus.Open)
            {
                if (circuitBreaker.ExpirationDate > DateTimeOffset.UtcNow)
                    throw new ApiException($"Circuit breaker is open");
                circuitBreaker.Status = CircuitBreakerStatus.HalfOpen;
            }

            do
            {
                try
                {
                    var response = await next();
                    circuitBreaker.Status = CircuitBreakerStatus.Closed;
                    return response;
                }
                catch (Exception ex)
                {
                    request.RetryTimes--;
                    _logger.LogError(ex.Message, ex.StackTrace);
                }
            } while (request.RetryTimes > 0 && circuitBreaker.Status != CircuitBreakerStatus.HalfOpen);

            circuitBreaker.Status = CircuitBreakerStatus.Open;
            circuitBreaker.ExpirationDate = DateTimeOffset.UtcNow.AddMinutes(request.TimeoutExpiration.TotalMinutes);

            var slidingExpiration = request.TimeoutExpiration * 2;
            await _cachingService.SetAsync(request.CircuitBreakerCacheKey, circuitBreaker, slidingExpiration, cancellationToken);
            throw new ApiException($"Circuit breaker is open");
        }
    }
}
