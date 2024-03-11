using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class WfxGDNHistory : BaseEntity
    {
        public int? ExportDetailId { get; set; }
        public virtual ExportDetail ExportDetail { get; set; }

        public int? WfxGDNId { get; set; }
        public virtual WfxGDN WfxGDN { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
    }

}
