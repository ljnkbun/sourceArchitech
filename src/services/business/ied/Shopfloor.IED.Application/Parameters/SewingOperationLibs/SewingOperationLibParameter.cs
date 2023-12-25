using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingOperationLibs
{
    public class SewingOperationLibParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? FolderTreeId { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalTMU { get; set; }
        public decimal? NoneMachineTime { get; set; }
        public decimal? LabourCost { get; set; }
        public bool? Deleted { get; set; }
    }
}
