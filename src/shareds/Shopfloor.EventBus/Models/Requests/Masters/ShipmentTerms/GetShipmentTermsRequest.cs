namespace Shopfloor.EventBus.Models.Requests
{
    public class GetShipmentTermsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
