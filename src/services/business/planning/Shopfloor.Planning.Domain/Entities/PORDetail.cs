using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Domain.Entities
{
    public class PORDetail : BaseEntity
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public int PORId { get; set; }
        public decimal OrderedQuantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PorType? TypePORDetail { get; set; }
        public POR POR { get; set; }
        public virtual ICollection<MergeSplitPorDetail> FromMergeSplitPorDetails { get; set; }
        public virtual ICollection<MergeSplitPorDetail> ToMergeSplitPorDetails { get; set; }
    }
}
