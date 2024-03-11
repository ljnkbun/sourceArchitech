using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingReportSettingDetails
{
    public class WeavingReportSettingDetailModel : BaseModel
    {
        public int WeavingReportSettingId { get; set; }

        public int GroupIndex { get; set; }

        public string Split { get; set; }

        public int Repeat { get; set; }
    }
}