namespace Shopfloor.EventBus.Models.Requests
{
    public class GetFabricContentsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
