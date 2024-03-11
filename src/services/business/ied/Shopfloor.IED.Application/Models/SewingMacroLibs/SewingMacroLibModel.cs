using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingMacroLibs
{
    public class SewingMacroLibModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FolderTreeId { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal TotalBasicMinutes { get; set; }
        public decimal NoneMachineTime { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public decimal BundleQuality { get; set; }
        public int? SewingComponentGroupId { get; set; }
        public bool Deleted { get; set; }
    }
}
