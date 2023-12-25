using Newtonsoft.Json;

namespace Shopfloor.Ambassador.Application.Models
{
    public class WfxArticle
    {
        public WfxArticle()
        {
            BaseColorList = new List<WfxArticleBaseColor>();
            BaseSizeList = new List<WfxArticleBaseSize>();
            FlexFieldList = new List<WfxArticleFlexField>();
        }
        public int ArticleID { get; set; }
        public string Category { get; set; }
        public string MaterialType { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDesc { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public string ConsumptionUOM { get; set; }
        public string PurchaseUOM { get; set; }
        public string StoringUOM { get; set; }
        public string ColorCard { get; set; }
        public string SizeWidthRange { get; set; }
        public decimal? MinimumQty { get; set; }
        public decimal? MaximumQty { get; set; }
        public decimal? OrderQtyMultiple { get; set; }
        public string Supplier { get; set; }
        public decimal? BuyingPrice { get; set; }
        public string BuyingCurrencyCode { get; set; }
        public string Buyer { get; set; }
        public string RestrictedItem { get; set; }
        public string OurContact { get; set; }
        public string Brand { get; set; }
        public string PricePer { get; set; }
        public string PerSizeCons { get; set; }
        [JsonProperty("Fabric_Material")]
        public string FabricMaterial { get; set; }
        public string DivisionName { get; set; }
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
        public string MachineryCode { get; set; }
        public string MachineryName { get; set; }
        public string Reference { get; set; }
        public string ModelNo { get; set; }
        public string MYear { get; set; }
        public string PackingTypeName { get; set; }
        public string StockTypeName { get; set; }
        public decimal? ReOrderLevel { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public decimal? MinimumOrderQty { get; set; }
        public decimal? RequirementMultiple { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOnDate { get; set; }
        List<WfxArticleBaseColor> baseColorList;
        public List<WfxArticleBaseColor> BaseColorList
        {
            get
            {
                if (baseColorList == null)
                    baseColorList = new List<WfxArticleBaseColor>();
                return baseColorList;
            }
            set
            {
                baseColorList = value;
            }
        }
        List<WfxArticleBaseSize> baseSizeList;
        public List<WfxArticleBaseSize> BaseSizeList
        {
            get
            {
                if (baseSizeList == null)
                    baseSizeList = new List<WfxArticleBaseSize>();
                return baseSizeList;
            }
            set
            {
                baseSizeList = value;
            }
        }
        List<WfxArticleFlexField> flexFieldList;
        public List<WfxArticleFlexField> FlexFieldList
        {
            get
            {
                if (flexFieldList == null)
                    flexFieldList = new List<WfxArticleFlexField>();
                return flexFieldList;
            }
            set
            {
                flexFieldList = value;
            }
        }
    }
    public class WfxArticleBaseColor
    {
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public int? ColorID { get; set; }
    }

    public class WfxArticleFlexField
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
    public class WfxArticleBaseSize
    {
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
    }
}

