using Shopfloor.Consumption.Domain.Enums;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Consumption.Domain.Entities
{
    public class TestEntity : BaseEntity
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType Type { get; set; }
    }
}
