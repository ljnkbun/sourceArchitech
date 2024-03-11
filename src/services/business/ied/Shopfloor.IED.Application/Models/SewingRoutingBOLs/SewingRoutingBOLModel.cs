using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingRoutingBOLs
{
    public class SewingRoutingBOLModel
    {
        public int? SewingOperationLibId { get; set; }
        public int? SewingFeatureLibId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public SewingRoutingType Type { get; set; }
        public string Description { get; set; }
        public decimal SMV { get; set; }
        public decimal TotalSMV { get; set; }
        public int LineNumber { get; set; }
        public string LineCode { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal NonMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public string QuatityPoints { get; set; }
        public string QualityComments { get; set; }
        public string Freq { get; set; }
        public decimal Effort { get; set; }
        public decimal AllowedTime { get; set; }
    }
}
