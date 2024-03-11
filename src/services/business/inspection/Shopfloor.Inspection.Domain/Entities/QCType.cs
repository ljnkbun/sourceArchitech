using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCType : BaseMasterEntity
    {
        public QCScreenType QCScreenType { get; set; }
        public virtual ICollection<QCDefinition> QCDefinitions { get; set; }

    }
}
