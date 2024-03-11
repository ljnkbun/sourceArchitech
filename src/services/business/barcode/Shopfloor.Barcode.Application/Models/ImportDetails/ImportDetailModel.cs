using Shopfloor.Barcode.Application.Models.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ImportDetails
{
    public class ImportDetailModel : BaseModel
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string PONo { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public ItemStatus? Status { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Grade { get; set; }
        public decimal? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string LotNo { get; set; }
        public string Site { get; set; }
        public string Note { get; set; }
        public int AriticleBarcodeId { get; set; }
        public int LocationId { get; set; }
        public virtual ArticleBarcodeModel ArticleBarcodeModel { get; set; }

    }
}
