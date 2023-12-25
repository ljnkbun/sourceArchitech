namespace Shopfloor.EventBus.Models.Responses
{
    public class GetCompanyCurrencyByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RateExchange { get; set; }
        public string Symbol { get; set; }
        public DateTime? ValidFrom { get; set; }
    }
}
