using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class TestGroup : BaseMasterEntity
    {
        public TestGroup() {
            Tests = new HashSet<Test>();
        }
        public string Buyer { get; set; }
		public string Category { get; set; }
		public GroupType GroupType { get; set; }
		public bool Mandatory { get; set; }
		public string Description { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
