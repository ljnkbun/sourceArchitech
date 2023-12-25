using Shopfloor.Ambassador.Application.Definations;

namespace Shopfloor.Ambassador.Application.Models
{
    public class CircuitBreaker
    {
        public CircuitBreakerStatus Status { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }

        public CircuitBreaker()
        {
            Status = CircuitBreakerStatus.Closed;
        }
    }
}
