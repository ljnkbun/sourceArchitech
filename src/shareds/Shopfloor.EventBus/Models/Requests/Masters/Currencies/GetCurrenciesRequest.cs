namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCurrenciesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
