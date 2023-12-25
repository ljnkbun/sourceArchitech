using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Category : BaseMasterEntity
    {
        public Category()
        {
            ProductGroups = new HashSet<ProductGroup>();
            CategoryMapMaterialTypes = new HashSet<CategoryMapMaterialType>();
        }
        public virtual ICollection<ProductGroup> ProductGroups { get; set; }
        public virtual ICollection<CategoryMapMaterialType> CategoryMapMaterialTypes { get; set; }
    }
}
