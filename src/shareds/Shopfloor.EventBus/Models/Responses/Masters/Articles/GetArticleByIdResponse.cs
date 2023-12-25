namespace Shopfloor.EventBus.Models.Responses
{
    public class GetArticleByIdResponse : BaseResponse
    {
        public int WFXArticleId { get; set; }
        public string Category { get; set; }
        public string MaterialType { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDesc { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public string FabricMaterial { get; set; }
        public string OurContact { get; set; }
        public string PurchaseUOM { get; set; }
        public string StoringUOM { get; set; }
        public string DivisionName { get; set; }
        public string ConsumptionUOM { get; set; }
        public string ColorCard { get; set; }
        public string SizeWidthRange { get; set; }
        public decimal? MinimumQty { get; set; }
        public decimal? MaximumQty { get; set; }
        public string Buyer { get; set; }
        public string RestrictedItem { get; set; }
        public string Supplier { get; set; }
        public string Brand { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string BuyingCurrencyCode { get; set; }
        public string PricePer { get; set; }
        public string PerSizeCons { get; set; }
        public decimal? OrderQtyMultiple { get; set; }
        public string Season { get; set; }
        public string BuyerStyleRef { get; set; }
        public string Gender { get; set; }
        public string ColorDefinition { get; set; }
        public decimal? SAM { get; set; }
        public decimal? SellingPrice { get; set; }
        public string SellingPriceCurrency { get; set; }
        public string BuyerDepartmentName { get; set; }
        public string HSCode { get; set; }
        public string StyleType { get; set; }
        public string Reference { get; set; }
        public string ModelNo { get; set; }
        public string MYear { get; set; }
        public string PackingTypeName { get; set; }
        public string StockTypeName { get; set; }
        public decimal? ReOrderLevel { get; set; }
        public decimal? MinimumOrderQty { get; set; }
        public decimal? RequirementMultiple { get; set; }
        public bool UseForIED { get; set; }
    }
}
