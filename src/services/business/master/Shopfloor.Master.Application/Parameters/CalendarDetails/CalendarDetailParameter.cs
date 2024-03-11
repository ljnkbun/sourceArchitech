using Shopfloor.Core.Models.Parameters;
using Shopfloor.Master.Domain.Enums;

namespace Shopfloor.Master.Application.Parameters.CalendarDetails
{
    public class CalendarDetailParameter : RequestParameter
    {
        public DayOfWeek? DayOfWeek { get; set; }
        public Shift? Shift { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public decimal? WorkingHours { get; set; }
        public decimal? BreakHours { get; set; }
        public int? CalendarId { get; set; }
    }
}
