using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Application.Models.CriticalParts
{
    public class CriticalPartModel : BaseModel
    {
		public int PlanningGroupId { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public int Priority { get; set; }
	}
}
