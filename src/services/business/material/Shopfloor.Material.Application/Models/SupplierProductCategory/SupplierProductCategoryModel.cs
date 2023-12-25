using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Material.Application.Models.SupplierProductCategory
{
    public class SupplierProductCategoryModel : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int SupplierId { get; set; }
    }
}