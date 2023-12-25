namespace Shopfloor.EventBus.Models.Responses
{
    public class GetSubCategoryByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SubCategoryGroupId { get; set; }
        public string ExciseTarrifNo { get; set; }
        public bool PackagingUnit { get; set; }
        public bool ByPassPriceList { get; set; }
        public bool DefaultInactiveIndent { get; set; }
        public int ProductGroupId { get; set; }
    }
}
