using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingOperationLibBOL : BaseEntity
    {
        public int SewingOperationLibId { get; set;}
        public int? SewingTaskLibId { get; set; }
        public int? SewingMacroLibId { get; set; }
        public OperationBOLType Type { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
        public virtual SewingTaskLib SewingTaskLib { get; set; }
        public virtual SewingMacroLib SewingMacroLib { get; set; }
        public virtual SewingOperationLib SewingOperationLib { get; set; }

    }
}
