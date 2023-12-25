namespace Shopfloor.EventBus.Models.Requests
{
    public class GetProductGroupsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? MaterialTypeId { get; set; }

    }
}
