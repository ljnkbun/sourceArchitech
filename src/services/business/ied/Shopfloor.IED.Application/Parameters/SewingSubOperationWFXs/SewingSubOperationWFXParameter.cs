using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.SewingSubOperationWFXs
{
    public class SewingSubOperationWFXParameter : RequestParameter
    {
        public int? SewingOperationWFXVersionId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string LineNumber { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalSMV { get; set; }
        public decimal? NonMachineTime { get; set; }
        public decimal? LabourCost { get; set; }
        public string QuatityPoints { get; set; }
        public string QualityComments { get; set; }
        public string Freq { get; set; }
        public decimal? Effort { get; set; }
        public decimal? AllowedTime { get; set; }
        public bool? Deleted { get; set; }
    }
}
