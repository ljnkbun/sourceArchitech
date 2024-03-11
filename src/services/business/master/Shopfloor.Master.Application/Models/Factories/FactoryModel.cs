using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.Factories
{
    public class FactoryModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionCode { get; set; }
        public List<int> ProcessIds { get; set; }
    }
}
