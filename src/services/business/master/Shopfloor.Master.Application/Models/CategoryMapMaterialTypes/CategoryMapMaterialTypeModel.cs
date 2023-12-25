using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.CategoryMapMaterialTypes
{
    public class CategoryMapMaterialTypeModel : BaseModel
    {
        public int CategoryId { get; set; }
        public int MaterialTypeId { get; set; }
    }
}
