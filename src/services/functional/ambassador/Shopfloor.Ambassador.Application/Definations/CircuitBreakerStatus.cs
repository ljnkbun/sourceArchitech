namespace Shopfloor.Ambassador.Application.Definations
{
    public enum CircuitBreakerStatus : byte
    {
        Closed = 1,
        HalfOpen = 2,
        Open = 3
    }
}
