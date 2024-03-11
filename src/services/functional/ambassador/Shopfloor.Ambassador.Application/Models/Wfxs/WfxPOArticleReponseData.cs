namespace Shopfloor.Ambassador.Application.Models.Wfxs
{

    public class WfxPOArticleReponseData
    {
        public int? ResponseID { get; set; }
        public string ErrorMsg { get; set; }
        public List<WfxOrderResponse> ResponseData { get; set; }
        public string Status { get; set; }
    }

    public class WfxOrderResponse
    {
        public List<WfxPOArticleData> OrderData { get; set; }
    }

    public class WfxPOArticleData
    {
        public string RMPONO { get; set; }
        public string OrderRefNum { get; set; }
        public string POStatus { get; set; }
        public string POCreationDate { get; set; }
        public string LastRevisedDate { get; set; }
        public string PurchaseOfficer { get; set; }
        public string ShipmentTerm { get; set; }
        public string PaymentTerm { get; set; }
        public string DeliveryTerms { get; set; }
        public string OCFactory { get; set; }
        public string FactorySite { get; set; }
        public string ShipToAddress { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ColorCodes { get; set; }
        public string ColorDesc { get; set; }
        public string SizeCodes { get; set; }
        public string SizeName { get; set; }
        public string TotalUnits { get; set; }
        public string UOM { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public string PPYDGDate { get; set; }
        public string InHouseDate { get; set; }
        public string OrderID { get; set; }
        public string ProductSubCat { get; set; }
        public int RMPOCreationYear { get; set; }
        public string RMPOCreationMonth { get; set; }
        public string Traceable { get; set; }
        public string MemberCompanyName { get; set; }
        public string Supplier { get; set; }

    }
}
