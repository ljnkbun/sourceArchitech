namespace Shopfloor.EventBus.Models.Requests
{
    public class GetTwistsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
