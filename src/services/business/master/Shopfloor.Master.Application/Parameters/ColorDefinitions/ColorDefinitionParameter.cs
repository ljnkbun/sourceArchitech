using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ColorDefinitions
{
    public class ColorDefinitionParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
