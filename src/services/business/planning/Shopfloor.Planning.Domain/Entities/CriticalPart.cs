using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
	public class CriticalPart : BaseEntity
	{
		public int PlanningGroupId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int Priority { get; set; }
	}
}
