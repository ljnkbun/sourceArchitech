using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class SubCategoryGroup : BaseMasterEntity
    {
        public SubCategoryGroup()
        {
            SubCategories = new HashSet<SubCategory>();
            Processs = new HashSet<Process>();
        }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<Process> Processs { get; set; }
    }
}
