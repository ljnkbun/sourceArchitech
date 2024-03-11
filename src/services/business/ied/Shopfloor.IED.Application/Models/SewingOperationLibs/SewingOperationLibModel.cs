using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingOperationLibs
{
    public class SewingOperationLibModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public string SubCategoryName { get; set; }
        public int SewingComponentId { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public decimal TotalSMV { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal LabourCost { get; set; }
        public int FolderTreeId { get; set; }
        public bool Deleted { get; set; }
    }
}
