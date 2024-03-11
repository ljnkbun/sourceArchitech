using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingOperationLibs
{
    public class SewingOperationLibParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int? SewingComponentId { get; set; }
        public int? FolderTreeId { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal? Contingency { get; set; }
        public decimal? TotalSMV { get; set; }
        public decimal? NoneMachineTime { get; set; }
        public decimal? LabourCost { get; set; }
        public bool? Deleted { get; set; }
    }
}
