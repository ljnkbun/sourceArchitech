using Shopfloor.Core.Models.Entities;
using Shopfloor.Production.Domain.Enums;

namespace Shopfloor.Production.Domain.Entities
{
    public class TestEntity : BaseEntity
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
    }
}
