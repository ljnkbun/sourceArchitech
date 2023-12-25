namespace Shopfloor.EventBus.Models.Requests
{
    public class GetPatternsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
