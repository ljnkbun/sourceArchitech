using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.QCDefinitionDefects
{
    public class QCDefinitionDefectParameter : RequestParameter
    {
        public int? QCDefinitionId { get; set; }
		public int? QCDefectId { get; set; }
    }
}
