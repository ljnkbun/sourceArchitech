using Shopfloor.Ambassador.Domain.Enums;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Ambassador.Application.Parameters.TestEntities
{
    public class TestEntityParameter : RequestParameter
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType? Type { get; set; }
    }
}
