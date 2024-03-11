using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.KnittingGreiges
{
    public class KnittingGreigeParameter : RequestParameter
    {
        public int? KnittingIEDId { get; set; }
        public int? KnittingBodyTypeId { get; set; }
        public int? KnittingTypeId { get; set; }
        public decimal? Width { get; set; }
        public decimal? WidthLossRate { get; set; }
        public decimal? WeightGM { get; set; }
        public decimal? WeightGMLossRate { get; set; }
        public decimal? VerticalDensity { get; set; }
        public decimal? VerticalDensityLossRate { get; set; }
        public decimal? HorizontalDensity { get; set; }
        public decimal? HorizontalDensityLossRate { get; set; }
        public decimal? WrapShrinkage { get; set; }
        public int? KnittingShrinkageId { get; set; }
        public decimal? WeftShrinkage { get; set; }
        public int? Gauge { get; set; }
        public decimal? Feeder { get; set; }
        public decimal? UsedFeeder { get; set; }
        public decimal? Needle { get; set; }
        public decimal? RappoLength { get; set; }
        public decimal? MachineDiameter { get; set; }
        public decimal? WeightKg { get; set; }
    }
}
