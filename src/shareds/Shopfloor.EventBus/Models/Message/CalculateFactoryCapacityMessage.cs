namespace Shopfloor.EventBus.Models.Message
{
    public class CalculateFactoryCapacityMessage
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
