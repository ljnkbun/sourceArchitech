using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class CapacityColor : BaseEntity
    {
        public string Color { get; set; }
		public decimal? FromRange { get; set; }
		public decimal? ToRange { get; set; }
    }
}
