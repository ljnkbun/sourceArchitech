using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingRappoMarks
{
    public class WeavingRappoMarkModel : BaseModel
    {
        public int WeavingRappoId { get; set; }
        public int ColumnNo { get; set; }
        public int PatternIndex { get; set; }
    }
}
