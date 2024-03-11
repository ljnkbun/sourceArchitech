using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class Machine : BaseMasterEntity
    {
        public string SerialNo { get; set; }
        public string Remarks { get; set; }
        public decimal? Capacity { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Process Process { get; set; }
    }
}
