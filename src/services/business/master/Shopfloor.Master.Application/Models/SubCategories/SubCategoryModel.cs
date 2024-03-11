using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.SubCategories
{
    public class SubCategoryModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SubCategoryGroupId { get; set; }
        public string SubCategoryGroupName { get; set; }
        public string SubCategoryGroupCode { get; set; }
        public string ExciseTarrifNo { get; set; }
        public bool PackagingUnit { get; set; }
        public bool ByPassPriceList { get; set; }
        public bool DefaultInactiveIndent { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public string ProductGroupCode { get; set; }
    }
}
