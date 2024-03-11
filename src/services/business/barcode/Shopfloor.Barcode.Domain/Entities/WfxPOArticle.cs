using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class WfxPOArticle : BaseEntity
    {
        public WfxPOArticle()
        {
            WfxPOArticleHistories = new HashSet<WfxPOArticleHistory>();
        }
        public string PONo { get; set; }
        public string OrderRefNum { get; set; }
        public string POStatus { get; set; }
        public DateTime? POCreationDate { get; set; }
        public DateTime? LastRevisedDate { get; set; }
        public string PurchaseOfficer { get; set; }
        public string ShipmentTerm { get; set; }
        public string PaymentTerm { get; set; }
        public string DeliveryTerms { get; set; }
        public string OCFactory { get; set; }
        public string FactorySite { get; set; }
        public string ShipToAddress { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public DateTime? PPYDGDate { get; set; }
        public DateTime? InHouseDate { get; set; }
        public string OrderID { get; set; }
        public string ProductSubCat { get; set; }
        public int RMPOCreationYear { get; set; }
        public string RMPOCreationMonth { get; set; }
        public string Traceable { get; set; }
        public string MemberCompanyName { get; set; }
        public string Supplier { get; set; }
        public virtual ICollection<WfxPOArticleHistory> WfxPOArticleHistories { get; set; }


    }

}
