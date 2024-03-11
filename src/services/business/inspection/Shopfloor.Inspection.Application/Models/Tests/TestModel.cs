using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Application.Models.Tests
{
    public class TestModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public int? TestGroupId { get; set; }
    }
}
