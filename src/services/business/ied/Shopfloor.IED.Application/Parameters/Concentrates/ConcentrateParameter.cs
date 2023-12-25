using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.Concentrates
{
    public class ConcentrateParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
