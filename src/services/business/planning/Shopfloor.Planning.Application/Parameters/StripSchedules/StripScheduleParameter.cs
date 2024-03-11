using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.StripSchedules
{
    public class StripScheduleParameter : RequestParameter
    {
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ProfileEfficiencyValue { get; set; }
        public decimal? OrderEfficiencyValue { get; set; }
        public decimal? StripEfficiencyValue { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Description { get; set; }
        public bool? IsManualPlanning { get; set; }
        public string Gauge { get; set; }
    }
}
