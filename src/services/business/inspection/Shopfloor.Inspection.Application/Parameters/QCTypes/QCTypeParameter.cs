using Shopfloor.Core.Models.Parameters;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Parameters.QCTypes
{
    public class QCTypeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public QCScreenType? QCScreenType { get; set; }

    }
}
