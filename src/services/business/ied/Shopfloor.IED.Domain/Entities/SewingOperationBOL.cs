using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperationBOL : BaseEntity
    {
        public int SewingOperationId { get; set;}
        public int? SewingTaskId { get; set; }
        public int? SewingMacroId { get; set; }
        public OperationBOLType Type { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
        public virtual SewingTask SewingTask { get; set; }
        public virtual SewingMacro SewingMacro { get; set; }
        public virtual SewingOperation SewingOperation { get; set; }

    }
}
