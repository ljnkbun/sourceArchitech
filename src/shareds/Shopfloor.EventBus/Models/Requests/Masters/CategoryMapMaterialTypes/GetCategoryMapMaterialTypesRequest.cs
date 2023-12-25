namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCategoryMapMaterialTypesRequest : BaseRequest
    {
        public int? CategoryId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
