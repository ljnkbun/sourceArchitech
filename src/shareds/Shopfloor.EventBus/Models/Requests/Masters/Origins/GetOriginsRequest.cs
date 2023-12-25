namespace Shopfloor.EventBus.Models.Requests
{
    public class GetOriginsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
