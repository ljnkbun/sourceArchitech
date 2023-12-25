namespace Shopfloor.EventBus.Models.Requests
{
    public class GetDeliveryTermsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
