using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingRappoMatrics
{
    public class WeavingRappoMatricModel : BaseModel
    {
        public int WeavingRappoId { get; set; }
        public int SlotIndex { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int LoopIndex { get; set; }
        public int HorizontalYarnId { get; set; }
        public int? VerticleYarnId { get; set; }
        public int BackgroundType { get; set; }
        public bool Deleted { get; set; }
    }
}
