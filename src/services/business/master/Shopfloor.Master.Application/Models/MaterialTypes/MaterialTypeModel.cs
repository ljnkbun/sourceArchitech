using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Application.Models.CategoryMapMaterialTypes;

namespace Shopfloor.Master.Application.Models.MaterialTypes
{
    public class MaterialTypeModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryMapMaterialTypeModel> CategoryMapMaterialTypes { get; set; }
    }
}
