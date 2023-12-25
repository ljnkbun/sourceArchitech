using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.TestEntities
{
    public class TestEntityModel : BaseModel
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
    }
}
