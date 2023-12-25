using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingMacroLibBOL : BaseEntity
    {
        public int SewingMacroLibId { get; set; }
        public int SewingTaskLibId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
        public virtual SewingTaskLib SewingTaskLib { get; set; }
        public virtual SewingMacroLib SewingMacroLib { get; set; }

    }
}
