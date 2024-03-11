using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Models.LineMachineCapacities
{
    public class LineMachineCapacityTermStadingCapacity
    {
        public DateTime Day {  get; set; }
        public string DayOfWeek { get; set; }
        public decimal? StandingCapacity { get; set; }
        public int? LineId { get; set; }
        public string LineName { get; set; }
        public int? MachineId { get; set; }
        public string MachineName { get; set; }
        public decimal? WorkingHours { get; set; }
    }

    public class LineOrMachineMapModel
    {
        public int? MachineId { get; set; }
        public string MachineName { get; set; }
        public decimal? CapacityMachine { get; set; }
        public int? LineId { get; set; }
        public string LineName { get; set; }
        public int? Worker { get; set; }
    }
}
