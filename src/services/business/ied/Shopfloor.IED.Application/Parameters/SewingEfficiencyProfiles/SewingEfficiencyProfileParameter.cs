using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingEfficiencyProfiles
{
    public class SewingEfficiencyProfileParameter : RequestParameter
    {
        public string Name { get; set; }
        public decimal? PersonalAllowance { get; set; }
        public decimal? MachineDelay { get; set; }
        public decimal? Contingency { get; set; }
        public bool? IsDefault { get; set; }
    }
}