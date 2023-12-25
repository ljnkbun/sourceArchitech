namespace Shopfloor.EventBus.Models.Requests
{
    public class GetPortsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
