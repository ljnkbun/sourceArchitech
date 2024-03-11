using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class FPPODetail : BaseEntity
    {
        public int FPPOId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Quantity { get; set; }
        public FPPO FPPO { get; set; }
    }
}
