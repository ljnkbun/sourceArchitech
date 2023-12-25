using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingMacroLibBOLs
{
    public class SewingMacroLibBOLModel : BaseModel
    {
        public int SewingTaskLibId { get; set; }
        public int SewingMacroLibId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
    }
}
