using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingTaskLibs
{
    public class SewingTaskLibModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal? BundleTime { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public decimal BundleQuality { get; set; }
        public TaskType TaskType { get; set; }
        public int? SewingMachineEfficiencyProfileId { get; set; }
        public int? SewingBundleId { get; set; }
        public bool Deleted { get; set; }
    }
}
