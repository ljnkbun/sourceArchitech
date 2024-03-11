using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class WfxGDIHistory : BaseEntity
    {
        public int? ExportDetailId { get; set; }
        public virtual ExportDetail ExportDetail { get; set; }

        public int? WfxGDIId { get; set; }
        public virtual WfxGDI WfxGDI { get; set; }

        public decimal? Quantity { get; set; }
        public decimal? RemainQuantity { get; set; }
    }

}
