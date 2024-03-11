using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.SewingMacroLibs
{
    public class SewingMacroLibParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? FolderTreeId { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? TotalBasicMinutes { get; set; }
        public decimal? NoneMachineTime { get; set; }
        public int? SewingComponentGroupId { get; set; }
        public bool? Deleted { get; set; }
    }
}
