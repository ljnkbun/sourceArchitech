using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingReportSetting : BaseEntity
    {
        public WeavingReportSetting()
        {
            WeavingReportSettingDetails = new HashSet<WeavingReportSettingDetail>();
        }

        public int WeavingIEDId { get; set; }

        public SettingType SettingType { get; set; }

        public int NumberOfSplit { get; set; }

        public int Repeat { get; set; }

        public bool Locked { get; set; }

        public virtual WeavingIED WeavingIED { get; set; }

        public virtual ICollection<WeavingReportSettingDetail> WeavingReportSettingDetails { get; set; }
    }
}