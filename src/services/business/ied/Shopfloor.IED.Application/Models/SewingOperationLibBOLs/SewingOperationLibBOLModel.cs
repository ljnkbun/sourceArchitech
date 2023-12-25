using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingOperationLibBOLs
{
    public class SewingOperationLibBOLModel : BaseModel
    {
        public int SewingOperationLibId { get; set; }
        public int? SewingTaskLibId { get; set; }
        public int? SewingMacroLibId { get; set; }
        public OperationBOLType Type { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
    }
}
