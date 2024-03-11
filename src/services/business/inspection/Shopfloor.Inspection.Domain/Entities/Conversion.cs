using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class Conversion : BaseMasterEntity
    {
        public Conversion()
        {
            QCDefinitions = new HashSet<QCDefinition>();
        }
        public int Value { get; set; }
        public virtual ICollection<QCDefinition> QCDefinitions { get; set; }
    }
}
