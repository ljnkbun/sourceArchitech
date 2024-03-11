using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCDefectType : BaseMasterEntity
    {
        public QCDefectType()
        {
            QCDefects = new HashSet<QCDefect>();
        }
        public virtual ICollection<QCDefect> QCDefects { get; set; }
    }
}
