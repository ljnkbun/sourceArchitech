namespace Shopfloor.EventBus.Models.Requests
{
    public class GetUOMsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
