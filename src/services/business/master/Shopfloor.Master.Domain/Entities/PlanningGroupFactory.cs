using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class PlanningGroupFactory : BaseEntity
    {
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }

        public virtual PlanningGroup PlanningGroup { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
