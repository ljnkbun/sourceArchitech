using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Application.Models.InspectionBySizes
{
    public class PrintBarcodeModel : BaseModel
    {
        public int? ProductionOutputId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Barcode { get; set; }
        public string BOMNo { get; set; }
        public string FPPONo { get; set; }
        public string FPPOType { get; set; }
        public string OCNo { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string UOM { get; set; }
        public string PackingUOM { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Composition { get; set; }
        public string ConeColor { get; set; }
        public string Remark { get; set; }
        public string LotNo { get; set; }
        public string Buyer { get; set; }
        public string MadeIn { get; set; }
        public decimal? Width { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
    }
}
