using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class CategoryMapMaterialType : BaseEntity
    {
        public virtual Category Category { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int MaterialTypeId { get; set; }
    }
}
