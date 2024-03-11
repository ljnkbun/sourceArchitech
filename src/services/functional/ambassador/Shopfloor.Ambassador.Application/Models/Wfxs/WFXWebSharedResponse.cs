namespace Shopfloor.Ambassador.Application.Models.Wfxs
{
    public class WFXWebSharedResponse<T>
    {
        public decimal? responseID { get; set; }
        public T responseData { get; set; }
        public string errorMsg { get; set; }
        public string status { get; set; }
        public int? statusCode { get; set; }
    }

    public class WfxWebSharedDetailResponse
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
        public List<MaterialTypeResponse> MaterialTypes { get; set; }
    }

    public class MaterialTypeResponse
    {
        public string MaterialType { get; set; }
        public string MaterialTypeID { get; set; }
    }
}
