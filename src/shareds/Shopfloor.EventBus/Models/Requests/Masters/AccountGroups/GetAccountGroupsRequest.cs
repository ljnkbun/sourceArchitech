namespace Shopfloor.EventBus.Models.Requests
{
    public class GetAccountGroupsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
