using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class ProcessTemplate : BaseMasterEntity
    {
        public ProcessTemplate()
        {
            ProcessTemplateItems = new HashSet<ProcessTemplateItem>();
         }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<ProcessTemplateItem> ProcessTemplateItems { get; set; }
    }
}
