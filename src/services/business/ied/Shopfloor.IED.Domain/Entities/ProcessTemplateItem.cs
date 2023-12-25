using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class ProcessTemplateItem : BaseEntity
    {
        public int ProcessTemplateId { get; set; }
        public int Division { get; set; }
        public int Priority { get; set; }
        public bool Deleted { get; set; }
        public virtual ProcessTemplate ProcessTemplate { get; set; }
    }
}
