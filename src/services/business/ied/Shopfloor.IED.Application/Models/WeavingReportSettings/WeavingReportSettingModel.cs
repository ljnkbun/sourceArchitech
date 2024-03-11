using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.WeavingReportSettings
{
    public class WeavingReportSettingModel : BaseModel
    {
        public int WeavingIEDId { get; set; }

        public SettingType SettingType { get; set; }

        public int NumberOfSplit { get; set; }

        public bool Locked { get; set; }

        public int Repeat { get; set; }
    }
}