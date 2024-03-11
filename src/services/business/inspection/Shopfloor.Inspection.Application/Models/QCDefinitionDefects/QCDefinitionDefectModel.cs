using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.QCDefects;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Models.QCDefinitionDefects
{
    public class QCDefinitionDefectModel : BaseModel
    {
        public int? QCDefinitionId { get; set; }
		public int? QCDefectId { get; set; }
        public QCDefectModel QCDefect { get; set; }
    }
}
