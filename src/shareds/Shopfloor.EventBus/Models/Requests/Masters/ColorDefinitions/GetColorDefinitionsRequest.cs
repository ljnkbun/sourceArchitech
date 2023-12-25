namespace Shopfloor.EventBus.Models.Requests
{
    public class GetColorDefinitionsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
