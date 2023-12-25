using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class FabricComposition : BaseEntity
    {
        public int MaterialRequestId { get; set; }

        public string ContentNameDesc { get; set; }

        public decimal Percentage { get; set; }

        public virtual MaterialRequest MaterialRequest { get; set; }
    }
}