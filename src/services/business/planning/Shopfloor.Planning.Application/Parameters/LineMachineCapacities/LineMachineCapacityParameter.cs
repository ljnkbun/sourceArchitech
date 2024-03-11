using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.LineMachineCapacities
{
    public class LineMachineCapacityParameter : RequestParameter
    {
        public int PlanningGroupId { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
    }
}
