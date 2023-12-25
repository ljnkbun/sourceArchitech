using Shopfloor.Core.Models.Parameters;
using Shopfloor.Production.Domain.Enums;

namespace Shopfloor.Production.Application.Parameters.TestEntities
{
    public class TestEntityParameter : RequestParameter
    {
        public string Property01 { get; set; }
        public string Property02 { get; set; }
        public TestClassType? Type { get; set; }
    }
}
