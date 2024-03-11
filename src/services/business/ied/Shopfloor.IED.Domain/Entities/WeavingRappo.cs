using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRappo : BaseEntity
    {
        public WeavingRappo()
        {
            WeavingRappoMarks = new HashSet<WeavingRappoMark>();
            WeavingRappoMatrics = new HashSet<WeavingRappoMatric>();
        }
        public int WeavingIEDId { get; set; }
        public int Line { get; set; }
        public int WarpPerMarginDentSplit { get; set; }
        public int WarpPerContentDentSplit { get; set; }
        public int TotalRappo { get; set; }
        public int AdditionYarn { get; set; }
        public string VerticalRappoComment { get; set; }
        public string HorizontalRappoComment { get; set; }
        public string DrawingComment { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingIED WeavingIED { get; set; }
        public virtual ICollection<WeavingRappoMark> WeavingRappoMarks { get; set; }
        public virtual ICollection<WeavingRappoMatric> WeavingRappoMatrics { get; set; }
    }
}
