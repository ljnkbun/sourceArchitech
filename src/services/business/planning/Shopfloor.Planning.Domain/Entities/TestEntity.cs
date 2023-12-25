using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Domain.Entities
{
    public class TestEntity : BaseEntity
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
    }
}
