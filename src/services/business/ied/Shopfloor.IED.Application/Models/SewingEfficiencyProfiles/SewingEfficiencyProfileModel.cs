using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Application.Models.SewingMachineEfficiencyProfiles;

namespace Shopfloor.IED.Application.Models.SewingEfficiencyProfiles
{
    public class SewingEfficiencyProfileModel : BaseModel
    {
        public string Name { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MachineDelay { get; set; }
        public decimal Contingency { get; set; }
        public bool? IsDefault { get; set; }
        public ICollection<SewingMachineEfficiencyProfileModel> SewingMachineEfficiencyProfiles { get; set; }
    }
}