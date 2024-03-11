using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class ArticleBarcode : BaseEntity
    {
        public ArticleBarcode()
        {
        }
        public string Barcode { get; set; }
        public virtual ICollection<BarcodeLocation> BarcodeLocations { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string PONo { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string GDINum { get; set; }
        public string OrderRefNum { get; set; }
        public string FPPOOCNUm { get; set; }
        public string SupplierName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
        public string ArticleUOM { get; set; }
        public string BarcodeUOM { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string LotNo { get; set; }
        public string Location { get; set; }
        public string Site { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string GroupCode { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PreLocationId { get; set; }


        public decimal? Balance { get; set; }
        public decimal? FPPOQty { get; set; }
        public decimal? UpdatedToDate { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }
    }
}
