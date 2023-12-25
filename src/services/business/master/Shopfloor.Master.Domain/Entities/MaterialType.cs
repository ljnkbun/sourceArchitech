using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class MaterialType : BaseMasterEntity
    {
        public MaterialType()
        {
            MaterialTypeMapProductGroups = new HashSet<MaterialTypeMapProductGroup>();
            CategoryMapMaterialTypes = new HashSet<CategoryMapMaterialType>();
        }

        public virtual int CategoryId { get; set; }
        public virtual ICollection<MaterialTypeMapProductGroup> MaterialTypeMapProductGroups { get; set; }
        public virtual ICollection<CategoryMapMaterialType> CategoryMapMaterialTypes { get; set; }
    }
}
