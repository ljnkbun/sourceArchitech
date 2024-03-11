using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.CriticalParts
{
    public class CriticalPartParameter : RequestParameter
    {
		public int? PlanningGroupId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int? Priority { get; set; }
	}
}
