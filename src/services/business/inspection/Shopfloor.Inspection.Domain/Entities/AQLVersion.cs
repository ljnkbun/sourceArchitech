using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class AQLVersion : BaseMasterEntity
    {
        public AQLVersion() {
            AQLs = new HashSet<AQL>();
            QCDefinitions = new HashSet<QCDefinition>();
        }
        public virtual ICollection<AQL> AQLs { get; set; }
        public virtual ICollection<QCDefinition> QCDefinitions { get; set; }
    }
}
