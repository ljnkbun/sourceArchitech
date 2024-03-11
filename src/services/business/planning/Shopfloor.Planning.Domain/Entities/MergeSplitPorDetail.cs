using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class MergeSplitPorDetail : BaseEntity
    {
        public int FromPorDetailId { get; set; }
        public int ToPorDetailId { get; set; }
        public decimal Quantity { get; set; }

        public PORDetail FromPorDetail { get; set; }
        public PORDetail ToPorDetail { get; set; }
    }
}
