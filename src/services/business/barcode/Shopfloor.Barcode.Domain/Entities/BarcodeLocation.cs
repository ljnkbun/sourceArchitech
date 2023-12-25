using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class BarcodeLocation : BaseEntity
    {
        public int LocationId { get; set; }
        public int ArticleBarcodeId { get; set; }
        public Location Location { get; set; }
        public ArticleBarcode ArticleBarcode { get; set; }
    }
}
