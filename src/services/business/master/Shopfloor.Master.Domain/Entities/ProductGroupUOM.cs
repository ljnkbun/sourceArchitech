using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ProductGroupUOM : BaseEntity
    {
        public int UOMId { get; set; }

        public int ProductGroupId { get; set; }

        public virtual UOM UOM { get; set; }

        public virtual ProductGroup ProductGroup { get; set; }
    }
}