using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingMacroLibBOL : BaseEntity
    {
        public int SewingMacroLibId { get; set; }
        public int? SewingTaskLibId { get; set; }
        public MacroBOLType Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LineNumber { get; set; }
        public string Freq { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public virtual SewingTaskLib SewingTaskLib { get; set; }
        public virtual SewingMacroLib SewingMacroLib { get; set; }

    }
}
