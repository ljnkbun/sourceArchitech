using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Production.Application.Parameters.InspectionBySizes
{
    public class InspectionBySizeParameter : RequestParameter
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
    }
}
