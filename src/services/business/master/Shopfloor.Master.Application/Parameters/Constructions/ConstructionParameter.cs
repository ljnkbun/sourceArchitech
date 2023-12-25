using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.Constructions
{
    public class ConstructionParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
