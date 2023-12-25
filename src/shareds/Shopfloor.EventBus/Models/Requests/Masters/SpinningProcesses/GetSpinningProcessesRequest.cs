namespace Shopfloor.EventBus.Models.Requests
{
    public class GetSpinningProcessesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
