namespace Shopfloor.Ambassador.Application.Behaviours
{
    public interface IAmbassadorQuery
    {
        int RetryTimes { get; set; }
        string CircuitBreakerCacheKey { get; }
        TimeSpan TimeoutExpiration { get; set; }
    }
}
