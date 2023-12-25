namespace Shopfloor.EventBus.Models.Requests
{
    public class GetGendersRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
