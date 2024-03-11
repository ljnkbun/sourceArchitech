using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class MergeSplitPOR : BaseEntity
    {
        public int FromPORId { get; set; }
		public int ToPORId { get; set; }
		public decimal Quantity { get; set; }

        public POR FromPOR { get; set; }
        public POR ToPOR { get; set; }
    }
}
