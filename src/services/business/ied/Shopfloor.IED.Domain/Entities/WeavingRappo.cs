using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRappo : BaseEntity
    {
        public WeavingRappo()
        {
            WeavingYarns = new HashSet<WeavingYarn>();
            WeavingRappoMarks = new HashSet<WeavingRappoMark>();
            WeavingRappoMatrics = new HashSet<WeavingRappoMatric>();
        }
        public int WeavingArticleId { get; set; }
        public int NumOfLine { get; set; }
        public int YarnOfBorder { get; set; }
        public int YarnOfBackground { get; set; }
        public int NumOfRappo { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingArticle WeavingArticle { get; set; }
        public virtual ICollection<WeavingYarn> WeavingYarns { get; set; }
        public virtual ICollection<WeavingRappoMark> WeavingRappoMarks { get; set; }
        public virtual ICollection<WeavingRappoMatric> WeavingRappoMatrics { get; set; }
    }
}
