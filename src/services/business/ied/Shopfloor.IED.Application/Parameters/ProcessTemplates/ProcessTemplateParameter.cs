using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.ProcessTemplates
{
    public class ProcessTemplateParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }

    }
}
