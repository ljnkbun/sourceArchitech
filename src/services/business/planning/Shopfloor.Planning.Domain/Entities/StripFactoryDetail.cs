using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripFactoryDetail : BaseEntity
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public int PorDetailId { get; set; }
        public PorType? TypePORDetail { get; set; }
        public int StripFactoryId { get; set; }
        public virtual StripFactory StripFactory { get; set; }
    }
}
