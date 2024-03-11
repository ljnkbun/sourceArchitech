using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Domain.Entities
{
    public class InspectionBySize : BaseEntity
    {
        public int? ProductionOutputId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public int? FPPOOutputDetailId { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
        public decimal? ActualWeight { get; set; }
        public decimal? CaptureMeter { get; set; }
        public decimal? CuttingWidth { get; set; }
        public decimal? WarpDensity { get; set; }
        public decimal? WeftDensity { get; set; }
        public string Remark { get; set; }
        public virtual ProductionOutput ProductionOutput { get; set; }
        public virtual FPPOOutputDetail FPPOOutputDetail { get; set; }
    }
}
