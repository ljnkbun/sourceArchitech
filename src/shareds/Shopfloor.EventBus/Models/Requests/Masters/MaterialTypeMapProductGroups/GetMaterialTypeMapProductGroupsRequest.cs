namespace Shopfloor.EventBus.Models.Requests
{
    public class GetMaterialTypeMapProductGroupsRequest : BaseRequest
    {
        public int? ProductGroupId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
