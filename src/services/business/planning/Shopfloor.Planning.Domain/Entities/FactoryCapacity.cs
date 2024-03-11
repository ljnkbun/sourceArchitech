using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class FactoryCapacity : BaseEntity
    {
        public int? FactoryId { get; set; }
        public string FactoryName { get; set; }
		public DateTime? Date { get; set; }
		public decimal? Standingcapacity { get; set; }
		public decimal? ActualCapacity { get; set; }
		public decimal? Percent { get; set; }
		public string ColorCode { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessName { get; set; }
        public int? PlanningGroupFactoryId { get; set; }
    }
}
