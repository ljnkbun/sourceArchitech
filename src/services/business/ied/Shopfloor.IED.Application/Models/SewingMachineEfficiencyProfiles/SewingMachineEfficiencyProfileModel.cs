using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingMachineEfficiencyProfiles
{
    public class SewingMachineEfficiencyProfileModel : BaseModel
    {
        public int SewingEfficiencyProfileId { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
    }
}