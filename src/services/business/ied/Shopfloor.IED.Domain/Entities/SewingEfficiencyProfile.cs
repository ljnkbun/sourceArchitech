using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingEfficiencyProfile : BaseNameEntity
    {
        public SewingEfficiencyProfile()
        {
            SewingMachineEfficiencyProfiles = new HashSet<SewingMachineEfficiencyProfile>();
            SewingSubcategoryEfficiencies = new HashSet<SewingSubcategoryEfficiency>();
        }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public bool? IsDefault { get; set; }
        public virtual ICollection<SewingMachineEfficiencyProfile> SewingMachineEfficiencyProfiles { get; set; }
        public virtual ICollection<SewingSubcategoryEfficiency> SewingSubcategoryEfficiencies { get; set; }
    }
}