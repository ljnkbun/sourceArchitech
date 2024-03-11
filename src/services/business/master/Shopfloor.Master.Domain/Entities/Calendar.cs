using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Calendar : BaseMasterEntity
    {
        public Calendar()
        {
            CalendarDetails = new HashSet<CalendarDetail>();
            PlanningGroups = new HashSet<PlanningGroup>();
        }
        public virtual ICollection<CalendarDetail> CalendarDetails { get; set; }
        public virtual ICollection<PlanningGroup> PlanningGroups { get; set; }
    }
}
