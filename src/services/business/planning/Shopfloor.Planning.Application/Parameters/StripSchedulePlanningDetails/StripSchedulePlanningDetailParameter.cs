using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.StripSchedulePlanningDetails
{
    public class StripSchedulePlanningDetailParameter : RequestParameter
    {
        public DateTime? Date { get; set; }
        public decimal? WorkingHours { get; set; }
        public decimal? StandardCapacity { get; set; }
        public decimal? ActualCapacity { get; set; }
        public decimal? ReceivedCapacity { get; set; }
        public string Description { get; set; }
        public int? StripScheduleId { get; set; }
    }
}
