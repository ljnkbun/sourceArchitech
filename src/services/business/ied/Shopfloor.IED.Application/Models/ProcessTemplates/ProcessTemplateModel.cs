using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.ProcessTemplates
{
    public class ProcessTemplateModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

    }
}
