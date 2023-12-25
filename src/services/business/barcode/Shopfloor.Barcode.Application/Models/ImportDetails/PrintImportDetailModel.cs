using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Models.ImportDetails
{
    public class PrintImportDetailModel
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public ItemStatus? Status { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public string ArticleBarcode { get; set; }
        public string GDNNumber { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string LotNo { get; set; }
        public string SupplierName { get; set; }
        public string Buyer { get; set; }
        public string OrderRefNum { get; set; }

    }
}
