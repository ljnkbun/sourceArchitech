using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingMachineEfficiencyProfile : BaseEntity
    {
        public SewingMachineEfficiencyProfile()
        {
            SewingTaskLibs = new HashSet<SewingTaskLib>();
        }
        public int SewingEfficiencyProfileId { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public virtual SewingEfficiencyProfile SewingEfficiencyProfile { get; set; }
        public virtual ICollection<SewingTaskLib> SewingTaskLibs { get; set; }
    }
}