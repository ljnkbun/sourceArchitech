using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRusticFabricSpec : BaseEntity
    {
        public int WeavingIEDId { get; set; }
        public int LineNumber { get; set; }
        public string ContentWeaveStyle { get; set; }
        public decimal HarnessFrameCWS { get; set; }
        public string MarginWeaveStyle { get; set; }
        public decimal HarnessFrameMWS { get; set; }
        public decimal WeightGM { get; set; }
        public decimal WeightGM2 { get; set; }
        public decimal WarpShrinkage { get; set; }
        public decimal WeftShrinkage { get; set; }
        public string MachineType { get; set; }
        public decimal RPM { get; set; }
        public decimal ReedCount { get; set; }
        public decimal ReedWidth { get; set; }
        public decimal WarpDensity { get; set; }
        public decimal WeftDensity { get; set; }
        public decimal GreigeWidth { get; set; }
        public decimal SettingWeftDensity { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingIED WeavingIED { get; set; }
    }
}
