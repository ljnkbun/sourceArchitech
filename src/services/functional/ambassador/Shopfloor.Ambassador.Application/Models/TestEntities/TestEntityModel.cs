using Shopfloor.Ambassador.Domain.Enums;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Ambassador.Application.Models.TestEntities
{
    public class TestEntityModel : BaseModel
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
    }
}
