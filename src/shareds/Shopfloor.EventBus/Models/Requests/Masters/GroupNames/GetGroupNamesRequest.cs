namespace Shopfloor.EventBus.Models.Requests
{
    public class GetGroupNamesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
