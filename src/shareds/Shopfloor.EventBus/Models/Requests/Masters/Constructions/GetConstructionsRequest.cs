namespace Shopfloor.EventBus.Models.Requests
{
    public class GetConstructionsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
