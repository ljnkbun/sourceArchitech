using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class SewingRate : BaseEntity
    {
        public decimal ExpectedQtyFrom { get; set; }
        public decimal ExpectedQtyTo { get; set; }
        public decimal EfficiencyRate { get; set; }
        public decimal CMRate { get; set; }
        public string Description { get; set; }
    }
}
