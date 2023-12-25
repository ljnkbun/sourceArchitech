namespace Shopfloor.EventBus.Models.Requests
{
    public class GetPricePersRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
