namespace Shopfloor.EventBus.Models.Responses
{
    public class GetMaterialTypeMapProductGroupByIdResponse : BaseResponse
    {
        public int? ProductGroupId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
