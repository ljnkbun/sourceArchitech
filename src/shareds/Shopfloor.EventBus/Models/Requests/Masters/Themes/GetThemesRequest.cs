namespace Shopfloor.EventBus.Models.Requests
{
    public class GetThemesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
