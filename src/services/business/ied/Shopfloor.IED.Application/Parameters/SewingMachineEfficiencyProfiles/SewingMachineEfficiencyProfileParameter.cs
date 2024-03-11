using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingMachineEfficiencyProfiles
{
    public class SewingMachineEfficiencyProfileParameter : RequestParameter
    {
        public int? SewingEfficiencyProfileId { get; set; }
        public int? MachineId { get; set; }
        public string MachineName { get; set; }
    }
}