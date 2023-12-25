using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class DCTemplate : BaseMasterEntity
    {
        public DCTemplate()
        {
            DCTemplateTasks = new HashSet<DCTemplateTask>();
        }

        public virtual ICollection<DCTemplateTask> DCTemplateTasks { get; set; }
    }
}