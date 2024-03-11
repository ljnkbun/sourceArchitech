using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Domain.Enums;

namespace Shopfloor.Master.Application.Models.CalendarDetails
{
    public class CalendarDetailModel : BaseModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public Shift Shift { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal WorkingHours { get; set; }
        public decimal BreakHours { get; set; }
        public int CalendarId { get; set; }
    }
}
