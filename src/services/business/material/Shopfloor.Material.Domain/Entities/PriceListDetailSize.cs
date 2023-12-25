using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class PriceListDetailSize : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int PriceListDetailId { get; set; }

        public PriceListDetail PriceListDetail { get; set; }
    }
}