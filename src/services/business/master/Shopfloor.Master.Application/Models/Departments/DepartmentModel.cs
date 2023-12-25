using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Departments
{
    public class DepartmentModel : BaseModel
    {
        public string Code{ get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
    }
}
