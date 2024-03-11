using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Line : BaseMasterEntity
    {
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Process Process { get; set; }
    }
}
