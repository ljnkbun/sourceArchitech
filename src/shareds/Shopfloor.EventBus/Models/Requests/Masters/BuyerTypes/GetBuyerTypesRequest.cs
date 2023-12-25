namespace Shopfloor.EventBus.Models.Requests
{
    public class GetBuyerTypesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
