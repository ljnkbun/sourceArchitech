using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class OrderEfficiency : BaseEntity
    {
        public string OCNo { get; set; }
        public decimal EfficiencyValue { get; set; }
    }
}
