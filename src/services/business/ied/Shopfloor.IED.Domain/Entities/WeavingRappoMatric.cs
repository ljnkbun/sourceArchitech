using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRappoMatric : BaseEntity
    {
        public WeavingRappoMatric()
        {
        }
        public int WeavingRappoId { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int LoopIndex { get; set; }
        public int HorizontalYarnId { get; set; }
        public int VerticleYarnId { get; set; }
        public int BackgroundType { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingRappo WeavingRappo { get; set; }
        public virtual WeavingYarn HorizontalYarn { get; set; }
        public virtual WeavingYarn VerticleYarn { get; set; }

    }
}
