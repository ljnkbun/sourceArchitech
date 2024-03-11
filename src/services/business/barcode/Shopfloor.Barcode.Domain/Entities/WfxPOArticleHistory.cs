using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class WfxPOArticleHistory : BaseEntity
    {
        public int? ImportDetailId { get; set; }
        public virtual ImportDetail ImportDetail { get; set; }

        public int? WfxPOArticlelId { get; set; }
        public virtual WfxPOArticle WfxPOArticle { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
    }

}
