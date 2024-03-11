using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.Tests
{
    public class TestParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public int? TestGroupId { get; set; }
    }
}
