using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.ProcessTemplateItems
{
    public class ProcessTemplateItemParameter : RequestParameter
    {
        public int? ProcessTemplateId { get; set; }
        public string Division { get; set; }
        public int? Priority { get; set; }
        public bool? Deleted { get; set; }

    }
}
