using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Models.FactoryCapacities
{
    public class FactoryCapacityTermStadingCapacity
    {
        public DateTime Day { get; set; }
        public string DayOfWeek { get; set; }
        public decimal? StandingCapacity { get; set; }
    }

    public class ColorStripSchedulePlanningDetail

    {
        public IReadOnlyList<CapacityColor> CapacityColors { get; set; }
        public IReadOnlyList<StripSchedulePlanningDetail> StripSchedulePlanningDetails { get; set; }
    }

    public class LineOrMachineMapModel
    {
        public int? MachineId { get; set; }
        public decimal? CapacityMachine { get; set; }
        public int? LineId { get; set; }
        public int? Worker { get; set; }
    }
}
