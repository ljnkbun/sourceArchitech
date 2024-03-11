using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingReportSettingDetail : BaseEntity
    {
        public int WeavingReportSettingId { get; set; }

        public int GroupIndex { get; set; }

        public string Split { get; set; }

        public int Repeat { get; set; }

        public virtual WeavingReportSetting WeavingReportSetting { get; set; }
    }
}