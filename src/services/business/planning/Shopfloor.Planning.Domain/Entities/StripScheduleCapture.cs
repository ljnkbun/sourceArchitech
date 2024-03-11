using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripScheduleCapture : BaseEntity
    {
        public StripScheduleCapture()
        {
            StripScheduleDetailCaptures = new HashSet<StripScheduleDetailCapture>();
            StripSchedulePlanningDetailCaptures = new HashSet<StripSchedulePlanningDetailCapture>();
        }

        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? ProfileEfficiencyValue { get; set; }
        public decimal? OrderEfficiencyValue { get; set; }
        public decimal? StripEfficiencyValue { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FromWorkingHours { get; set; }
        public int ToWorkingHours { get; set; }
        public string Description { get; set; }
        public bool IsManualPlanning { get; set; }

        public virtual ICollection<StripScheduleDetailCapture> StripScheduleDetailCaptures { get; set; }
        public virtual ICollection<StripSchedulePlanningDetailCapture> StripSchedulePlanningDetailCaptures { get; set; }
    }
}
