using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class SubCategoryGroup : BaseMasterEntity
    {
        public SubCategoryGroup()
        {
            SubCategories = new HashSet<SubCategory>();
        }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
