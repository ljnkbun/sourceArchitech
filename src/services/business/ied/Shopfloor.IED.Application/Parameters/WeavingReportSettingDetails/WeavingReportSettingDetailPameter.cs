using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.WeavingReportSettingDetails
{
    public class WeavingReportSettingDetailParameter : RequestParameter
    {
        public int? WeavingReportSettingId { get; set; }

        public int? GroupIndex { get; set; }

        public string Split { get; set; }

        public int? Repeat { get; set; }
    }
}