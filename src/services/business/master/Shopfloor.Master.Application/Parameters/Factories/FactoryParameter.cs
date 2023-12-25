using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Factories
{
    public class FactoryParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }

    }
}
