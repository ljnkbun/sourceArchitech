using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class FourPointsSystem : BaseMasterEntity
    {
        public FourPointsSystem() {
            QCDefinitions = new HashSet<QCDefinition>();
            FourPointsSystemDetails = new HashSet<FourPointsSystemDetail>();
        }
        public string ProductGroup { get; set; }
        public virtual ICollection<QCDefinition> QCDefinitions { get; set; }
        public virtual ICollection<FourPointsSystemDetail> FourPointsSystemDetails { get; set; }

    }
}
