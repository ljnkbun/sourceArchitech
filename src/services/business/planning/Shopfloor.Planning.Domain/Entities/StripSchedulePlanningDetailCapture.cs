using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripSchedulePlanningDetailCapture : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal StandardCapacity { get; set; }
        public decimal ActualCapacity { get; set; }
        public decimal ReceivedCapacity { get; set; }
        public string Description { get; set; }
        public int StripScheduleCaptureId { get; set; }
        public virtual StripScheduleCapture StripScheduleCapture { get; set; }
    }
}
