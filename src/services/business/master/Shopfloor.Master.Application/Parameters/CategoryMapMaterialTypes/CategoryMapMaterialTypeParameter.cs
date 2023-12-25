using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.CategoryMapMaterialTypes
{
    public class CategoryMapMaterialTypeParameter : RequestParameter
    {
        public int? CategoryId { get; set; }
        public int? MaterialTypeId { get; set; }
    }
}
