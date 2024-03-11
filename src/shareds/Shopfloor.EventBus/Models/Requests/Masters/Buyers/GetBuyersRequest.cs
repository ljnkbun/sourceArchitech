namespace Shopfloor.EventBus.Models.Requests.Masters.Buyers
{
    public class GetBuyersRequest : BaseRequest
    {
        public string WFXBuyerId { get; set; }
        public string Name { get; set; }
    }
}
