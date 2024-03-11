using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripScheduleDetail : BaseEntity
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripScheduleId { get; set; }
        public virtual StripSchedule StripSchedule { get; set; }
    }
}
