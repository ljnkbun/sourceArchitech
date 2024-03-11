using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingReportSettings
{
    public class WeavingReportSettingParameter : RequestParameter
    {
        public int? WeavingIEDId { get; set; }

        public SettingType? SettingType { get; set; }

        public int? NumberOfSplit { get; set; }
        
        public bool? Locked { get; set; }

        public int? Repeat { get; set; }
    }
}