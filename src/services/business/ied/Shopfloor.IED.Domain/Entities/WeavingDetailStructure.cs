using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingDetailStructure : BaseEntity
    {
        public int WeavingArticleId { get; set; }
        public StructureType StructureType { get; set; }
        public int CombString { get; set; }
        public int SlotNumber { get; set; }
        public int Total { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingArticle WeavingArticle { get; set; }
    }
}
