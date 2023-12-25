namespace Shopfloor.EventBus.Models.Requests.Divisions
{
    public class GetDivisionsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}