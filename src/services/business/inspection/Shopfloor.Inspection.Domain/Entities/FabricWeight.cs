using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class FabricWeight : BaseMasterEntity
    {
        public FabricWeight() {
            QCDefinitions = new HashSet<QCDefinition>();
            OneHundredPointSystems = new HashSet<OneHundredPointSystem>();
        }
        public virtual ICollection<OneHundredPointSystem> OneHundredPointSystems { get; set; }
        public virtual ICollection<QCDefinition> QCDefinitions { get; set; }
    }
}
