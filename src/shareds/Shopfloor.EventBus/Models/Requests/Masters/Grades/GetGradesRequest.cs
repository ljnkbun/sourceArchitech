namespace Shopfloor.EventBus.Models.Requests
{
    public class GetGradesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
