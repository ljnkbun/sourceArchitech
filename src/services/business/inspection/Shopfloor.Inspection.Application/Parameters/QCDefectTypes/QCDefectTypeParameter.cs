using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.QCDefectTypes
{
    public class QCDefectTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}
