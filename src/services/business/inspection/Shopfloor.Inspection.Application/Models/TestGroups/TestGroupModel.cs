using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.TestGroups
{
    public class TestGroupModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public GroupType? GroupType { get; set; }
		public bool? Mandatory { get; set; }
		public string Description { get; set; }
    }
}
