namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCountriesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
