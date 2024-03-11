using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.QCTypes
{
    public class QCTypeModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public QCScreenType? QCScreenType { get; set; }

    }
}
