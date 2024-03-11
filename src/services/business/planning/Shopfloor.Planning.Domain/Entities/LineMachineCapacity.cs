using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class LineMachineCapacity : BaseEntity
    {
        public int? MachineId { get; set; }
        public string MachineName { get; set; }
        public int? LineId { get; set; }
        public string LineName { get; set; }
        public DateTime? Date { get; set; }
		public decimal? Standingcapacity { get; set; }
        public decimal? WorkingHours { get; set; }
    }
}
