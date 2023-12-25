using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class MaterialTypeMapProductGroup : BaseEntity
    {
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        public virtual int ProductGroupId { get; set; }
        public virtual int MaterialTypeId { get; set; }
    }
}
