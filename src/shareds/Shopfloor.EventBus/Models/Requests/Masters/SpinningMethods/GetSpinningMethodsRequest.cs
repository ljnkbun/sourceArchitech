namespace Shopfloor.EventBus.Models.Requests
{
    public class GetSpinningMethodsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
