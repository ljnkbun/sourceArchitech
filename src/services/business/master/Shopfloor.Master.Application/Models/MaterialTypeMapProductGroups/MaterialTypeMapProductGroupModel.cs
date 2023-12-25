using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.MaterialTypeMapProductGroups
{
    public class MaterialTypeMapProductGroupModel : BaseModel
    {
        public int ProductGroupId { get; set; }
        public int MaterialTypeId { get; set; }
    }
}
