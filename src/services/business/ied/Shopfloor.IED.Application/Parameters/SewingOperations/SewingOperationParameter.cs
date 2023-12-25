using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingOperations
{
    public class SewingOperationParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LineCode { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalTMU { get; set; }
        public decimal? NoneMachineTime { get; set; }
        public decimal? LabourCost { get; set; }
        public bool? Deleted { get; set; }
    }
}
