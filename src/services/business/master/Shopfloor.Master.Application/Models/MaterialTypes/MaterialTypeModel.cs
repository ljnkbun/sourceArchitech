using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.MaterialTypes
{
    public class MaterialTypeModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }

    }
}
