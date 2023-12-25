namespace Shopfloor.EventBus.Models.Requests
{
    public class GetProcessesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
