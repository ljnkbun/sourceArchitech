
using Newtonsoft.Json;

namespace Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs
{
    public class GetWfxPorResponse
    {
        public string ProductionOrderNo { get; set; }

        [JsonProperty("Production Order ID")]
        public int ProductionOrderID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

        [JsonProperty("Created On")]
        public string CreatedOn { get; set; }

        [JsonProperty("Created By")]
        public string CreatedBy { get; set; }

        [JsonProperty("Modified On")]
        public string ModifiedOn { get; set; }

        [JsonProperty("Modified By")]
        public string ModifiedBy { get; set; }

        [JsonProperty("User Group")]
        public string UserGroup { get; set; }

        [JsonProperty("OC/SR/Service No")]
        public string OCSRServiceNo { get; set; }
        public int OrderID { get; set; }

        [JsonProperty("OC Status")]
        public string OCStatus { get; set; }

        [JsonProperty("Order Type")]
        public string OrderType { get; set; }

        [JsonProperty("Parent OC No")]
        public string ParentOCNo { get; set; }
        public string Buyer { get; set; }

        [JsonProperty("Buyer Order Ref")]
        public string BuyerOrderRef { get; set; }

        [JsonProperty("Garment Del Date")]
        public string GarmentDelDate { get; set; }

        [JsonProperty("BOM No")]
        public string BOMNo { get; set; }

        [JsonProperty("BOM ID")]
        public int BOMID { get; set; }
        public string Category { get; set; }

        [JsonProperty("Product Group")]
        public string ProductGroup { get; set; }

        [JsonProperty("Sub Category")]
        public string SubCategory { get; set; }

        [JsonProperty("Buyer Style Ref")]
        public string BuyerStyleRef { get; set; }
        public string Season { get; set; }

        [JsonProperty("Article Name")]
        public string ArticleName { get; set; }

        [JsonProperty("Article Code")]
        public string ArticleCode { get; set; }

        [JsonProperty("Article ID")]
        public int ArticleID { get; set; }
        public string UOM { get; set; }
        public string Process { get; set; }
        public int ProcessID { get; set; }

        [JsonProperty("Material Sync Date")]
        public string MaterialSyncDate { get; set; }

        [JsonProperty("Total Qty")]
        public double TotalQty { get; set; }
        public List<PorDetailResponse> ColorSizeDetails { get; set; }
    }

    public class PorDetailResponse
    {
        [JsonProperty("Color Name")]
        public string ColorName { get; set; }

        [JsonProperty("Color Code")]
        public string ColorCode { get; set; }
        public string Size { get; set; }

        [JsonProperty("Ordered Qty")]
        public double OrderedQty { get; set; }

        [JsonProperty("Allocated Qty")]
        public int AllocatedQty { get; set; }

        [JsonProperty("Qty to be allocated")]
        public int Qtytobeallocated { get; set; }
    }
}
