using Shopfloor.Core.Models.Entities;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Models.PlanningGroups
{
    public class PlanningGroupModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessId { get; set; }
        public int CalendarId { get; set; }

        public ICollection<PlanningGroupFactory> PlanningGroupFactories { get; set; }
    }
}
