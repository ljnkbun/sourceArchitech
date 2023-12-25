namespace Shopfloor.EventBus.Models.Requests
{
    public class GetStaplesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
