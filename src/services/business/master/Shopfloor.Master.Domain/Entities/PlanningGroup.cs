using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class PlanningGroup : BaseMasterEntity
    {
        public PlanningGroup()
        {
            PlanningGroupFactories = new HashSet<PlanningGroupFactory>();
        }
        public int ProcessId { get; set; }
        public int CalendarId { get; set; }

        public virtual Process Process { get; set; }
        public virtual Calendar Calendar { get; set; }
        public ICollection<PlanningGroupFactory> PlanningGroupFactories { get; set; }
    }
}
