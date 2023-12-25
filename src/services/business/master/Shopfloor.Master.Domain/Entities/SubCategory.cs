using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class SubCategory : BaseMasterEntity
    {
        public int SubCategoryGroupId { get; set; }
        public string ExciseTarrifNo { get; set; }
        public bool PackagingUnit { get; set; }
        public bool ByPassPriceList { get; set; }
        public bool DefaultInactiveIndent { get; set; }
        public int ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual SubCategoryGroup SubCategoryGroup { get; set; }
    }
}
