namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCetificatesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
