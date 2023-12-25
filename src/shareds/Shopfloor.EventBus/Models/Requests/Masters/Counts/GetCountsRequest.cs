namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCountsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
