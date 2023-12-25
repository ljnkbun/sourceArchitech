namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCountTypesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
