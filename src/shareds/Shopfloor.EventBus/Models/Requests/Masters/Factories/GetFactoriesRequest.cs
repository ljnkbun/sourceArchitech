namespace Shopfloor.EventBus.Models.Requests.Masters.Factories
{
    public class GetFactoriesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }
    }
}
