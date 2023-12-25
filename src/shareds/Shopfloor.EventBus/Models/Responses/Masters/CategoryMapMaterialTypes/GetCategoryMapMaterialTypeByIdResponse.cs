namespace Shopfloor.EventBus.Models.Responses
{
    public class GetCategoryMapMaterialTypeByIdResponse : BaseResponse
    {
        public int? CategoryId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
