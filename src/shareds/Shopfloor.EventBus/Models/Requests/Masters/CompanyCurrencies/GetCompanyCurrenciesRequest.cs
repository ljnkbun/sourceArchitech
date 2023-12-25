namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCompanyCurrenciesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime? ValidFrom { get; set; }
    }
}
