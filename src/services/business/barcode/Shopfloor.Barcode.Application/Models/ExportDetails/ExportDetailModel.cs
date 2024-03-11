using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ExportDetails
{
    public class ExportDetailModel : BaseModel
    {
        public ItemStatus? Status { get; set; }

        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public int? ExportArticleId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string Shade { get; set; }
        public string Grade { get; set; }
        public string OC { get; set; }
        public string UOM { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string No { get; set; }
        public string Barcode { get; set; }
        public string ParentBarcode { get; set; }
        public string OCRefNum { get; set; }
        public string LotNo { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public decimal? RemainQuantity { get; set; }
        public decimal? WeightPerCone { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? Quantity { get; set; }
        public string Note { get; set; }
        public virtual ArticleBarcodeModel ArticleBarcodeModel { get; set; }
    }
}
