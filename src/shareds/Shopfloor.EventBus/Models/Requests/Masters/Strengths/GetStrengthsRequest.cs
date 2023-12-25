namespace Shopfloor.EventBus.Models.Requests
{
    public class GetStrengthsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
