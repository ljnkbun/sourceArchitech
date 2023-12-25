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
        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? PreLocationId { get; set; }
    }
}
