namespace Shopfloor.EventBus.Models.Requests
{
    public class GetGaugesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
