using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Command.AQLs;
using Shopfloor.Inspection.Application.Models.AQLs;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Models.AQLVersions
{
    public class AQLVersionModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<AQLModel> AQLs { get; set; }
    }
}
