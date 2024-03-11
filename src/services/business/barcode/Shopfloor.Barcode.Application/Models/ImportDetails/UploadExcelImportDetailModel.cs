namespace Shopfloor.Barcode.Application.Models.ImportPODetails
{

    public class UploadExcelImportDetailModel
    {
        public string PONo { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? QuantityYard { get; set; }
        public decimal? QuantityMeter { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string BarCode { get; set; }
        public int? Status { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public int LocationId { get; set; }
        public int ArticleBarCodeId { get; set; }

    }
}
