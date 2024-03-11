using Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups;

namespace Shopfloor.EventBus.Models.Responses
{
    public class GetCalendarByIdResponse : BaseResponse
    {
        public GetCalendarByIdResponse()
        {
            CalendarDetails = new List<CalendarDetail>();
        }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<CalendarDetail> CalendarDetails { get; set; }
    }

    public class CalendarDetail
    {
        public int CalendarId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal BreakHours { get; set; }
    }
}
