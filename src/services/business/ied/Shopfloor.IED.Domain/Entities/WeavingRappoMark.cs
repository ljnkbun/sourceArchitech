using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRappoMark : BaseEntity
    {
        public int WeavingRappoId { get; set; }
        public int ColumnNo { get; set; }
        public int PatternIndex { get; set; }
        public bool Type { get; set; }
        public virtual WeavingRappo WeavingRappo { get; set; }
    }
}
