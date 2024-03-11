using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.StripFactoryDetails;
using Shopfloor.Planning.Application.Models.StripFactorySchedules;
using Shopfloor.Planning.Application.Models.StripScheduleDetails;
using Shopfloor.Planning.Application.Models.StripSchedulePlanningDetails;

namespace Shopfloor.Planning.Application.Models.StripSchedules
{
    public class CalculateStripScheduleModel : BaseModel
    {
        public int? StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public decimal Quantity { get; set; }
        public decimal? ProfileEfficiencyValue { get; set; }
        public decimal? OrderEfficiencyValue { get; set; }
        public decimal? StripEfficiencyValue { get; set; }
        public int? LearningCurveEfficiencyId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal FromWorkingHours { get; set; }
        public decimal ToWorkingHours { get; set; }
        public string Description { get; set; }
        public bool IsManualPlanning { get; set; }
        public virtual ICollection<StripFactoryScheduleModel> StripFactorySchedules { get; set; }
        public virtual ICollection<StripScheduleDetailModel> StripScheduleDetails { get; set; }
        public virtual ICollection<StripFactoryDetailModel> StripFactoryDetails { get; set; }
        public virtual ICollection<StripSchedulePlanningDetailModel> StripSchedulePlanningDetails { get; set; }
    }
}
