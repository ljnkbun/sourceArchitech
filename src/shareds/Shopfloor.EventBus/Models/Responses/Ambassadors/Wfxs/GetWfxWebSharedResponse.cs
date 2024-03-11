namespace Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs
{
    public class GetWfxWebSharedResponse
    {
        public List<WfxWebSharedDto> Data { get; set; }
    }

    public class WfxWebSharedDto
    {
        public string ProductGroupCode { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategoryCode { get; set; }
        public string ProductSubCategoryName { get; set; }
        public string ProductSubCategoryGroupName { get; set; }
        public string ExciseTarrifNum { get; set; }
        public object MovementUOM { get; set; }
        public string PackagingUnits { get; set; }
        public string RestrictMultiColorSize { get; set; }
        public string QCRequest { get; set; }
        public List<MaterialTypeDto> MaterialTypes { get; set; }
    }

    public class MaterialTypeDto
    {
        public string MaterialType { get; set; }
        public string MaterialTypeID { get; set; }
    }
}
