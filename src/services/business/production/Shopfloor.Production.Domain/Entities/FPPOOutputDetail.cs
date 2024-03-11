using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Domain.Entities
{
    public class FPPOOutputDetail : BaseEntity
    {
        public int? FPPOOutputId { get; set; }
        public decimal? PlannedQty { get; set; }
        public decimal? MadeQty { get; set; }
        public decimal? BalanceQty { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public virtual FPPOOutput FPPOOutput { get; set; }
    }
}
