using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Models.ExportDetails
{
    public class PrintExportDetailModel
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string PONo { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Staple { get; set; }
        public string BaleNo { get; set; }
        public string RollNo { get; set; }
        public string PackingNo { get; set; }
        public string LotNo { get; set; }
        public string Origin { get; set; }
        public string Micronaire { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string Color { get; set; }
        public string Composition { get; set; }
        public string Reference { get; set; }
        public string GarmentStyle { get; set; }
        public string Unit { get; set; }
        public ItemStatus? Status { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Size { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public string ArticleBarcode { get; set; }
        public string GDNNumber { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string SupplierName { get; set; }
        public string Buyer { get; set; }
        public string OrderRefNum { get; set; }

    }
}
