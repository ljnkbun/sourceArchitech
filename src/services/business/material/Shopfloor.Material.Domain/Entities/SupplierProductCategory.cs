using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Domain.Entities
{
    public class SupplierProductCategory : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}