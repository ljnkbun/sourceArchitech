using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Application.Models.Categories;

namespace Shopfloor.Master.Application.Models.CategoryMapMaterialTypes
{
    public class CategoryMapMaterialTypeModel : BaseModel
    {
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
