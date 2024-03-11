using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class Test : BaseMasterEntity
    {
        public string Description { get; set; }
		public int TestGroupId { get; set; }
        public virtual TestGroup TestGroup { get; set; }
    }
}
