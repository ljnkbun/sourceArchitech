using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class OneHundredPointSystem : BaseMasterEntity
    {
        public OneHundredPointSystem() {
            QCDefinitions = new HashSet<QCDefinition>();
            OneHundredPointSystemDetails = new HashSet<OneHundredPointSystemDetail>();
        }
        public virtual ICollection<QCDefinition> QCDefinitions { get; set; }
        public virtual ICollection<OneHundredPointSystemDetail> OneHundredPointSystemDetails { get; set; }

    }
}
