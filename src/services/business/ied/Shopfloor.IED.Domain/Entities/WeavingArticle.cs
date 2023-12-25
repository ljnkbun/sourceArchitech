using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingArticle : BaseEntity
    {
        public WeavingArticle()
        {
            WeavingRoutings = new HashSet<WeavingRouting>();
            WeavingRusticFabricSpecs = new HashSet<WeavingRusticFabricSpec>();
            WeavingRappos = new HashSet<WeavingRappo>();
            WeavingDetailStructures = new HashSet<WeavingDetailStructure>();
            WeavingYarns = new HashSet<WeavingYarn>();
        }
        public int WeavingIEDId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingIED WeavingIED { get; set; }
        public virtual ICollection<WeavingRouting> WeavingRoutings { get; set; }
        public virtual ICollection<WeavingRusticFabricSpec> WeavingRusticFabricSpecs { get; set; }
        public virtual ICollection<WeavingRappo> WeavingRappos { get; set; }
        public virtual ICollection<WeavingDetailStructure> WeavingDetailStructures { get; set; }
        public virtual ICollection<WeavingYarn> WeavingYarns { get; set; }

    }
}
