using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Application.Models.CalendarDetails;

namespace Shopfloor.Master.Application.Models.Calendars
{
    public class CalendarModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CalendarDetailModel> CalendarDetails { get; set; }
    }
}
