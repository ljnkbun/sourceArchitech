using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Factory : BaseMasterEntity
    {
        public Factory()
        {
            Machines = new HashSet<Machine>();
            Lines = new HashSet<Line>();
            PlanningGroupFactories = new HashSet<PlanningGroupFactory>();
        }

        public int? DivisionId { get; set; }
        public virtual Division Divsion { get; set; }

        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<Line> Lines { get; set; }
        public ICollection<PlanningGroupFactory> PlanningGroupFactories { get; set; }
    }
}
