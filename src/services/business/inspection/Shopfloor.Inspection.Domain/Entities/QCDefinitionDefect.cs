using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCDefinitionDefect : BaseEntity
    {
        public int QCDefinitionId { get; set; }
		public int QCDefectId { get; set; }
        public virtual QCDefinition QCDefinition { get; set; }
        public virtual QCDefect QCDefect { get; set; }
    }
}
