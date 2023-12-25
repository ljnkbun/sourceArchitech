using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.DCTemplates
{
    public class DCTemplateParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}