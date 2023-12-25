using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.SewingMacroBOLs
{
    public class SewingMacroBOLModel : BaseModel
    {
        public int SewingMacroId { get; set; }
        public int SewingTaskId { get; set; }
        public int LineNumber { get; set; }
        public decimal Freq { get; set; }
        public decimal TotalTMU { get; set; }
    }
}
