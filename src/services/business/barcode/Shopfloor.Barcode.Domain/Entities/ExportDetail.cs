using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class ExportDetail : BaseMasterEntity
    {
        public ItemStatus? Status { get; set; }
        public int? ExportArticleId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
        public string UOM { get; set; }
        public decimal? Yard { get; set; }
        public decimal? Meter { get; set; }
        public decimal? Unit { get; set; }
        public string Note { get; set; }
        public virtual ExportArticle ExportArticle { get; set; }
        public virtual ArticleBarcode ArticleBarcode { get; set; }
    }

}
