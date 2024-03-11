using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingTaskLib : BaseMasterEntity
    {
        public SewingTaskLib()
        {
            SewingMacroLibBOLs = new HashSet<SewingMacroLibBOL>();
            SewingOperationLibBOLs = new HashSet<SewingOperationLibBOL>();
        }
        public string Description { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal? BundleTime { get; set; }
        public TaskType TaskType { get; set; }
        public int? SewingMachineEfficiencyProfileId { get; set; }
        public int? SewingBundleId { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<SewingMacroLibBOL> SewingMacroLibBOLs { get; set; }
        public virtual ICollection<SewingOperationLibBOL> SewingOperationLibBOLs { get; set; }
        public virtual SewingMachineEfficiencyProfile SewingMachineEfficiencyProfile { get; set; }
        public virtual SewingBundle SewingBundle { get; set; }
    }
}
