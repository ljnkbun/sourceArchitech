using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingMacroBOL : BaseEntity
    {
        public int SewingMacroId { get; set; }
        public int SewingTaskId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
        public virtual SewingTask SewingTask { get; set; }
        public virtual SewingMacro SewingMacro { get; set; }
    }
}
