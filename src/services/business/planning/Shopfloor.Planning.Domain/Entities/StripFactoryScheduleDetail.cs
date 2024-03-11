using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripFactoryScheduleDetail : BaseEntity
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string UOM { get; set; }
        public decimal Quantity { get; set; }
        public int StripFactoryScheduleId { get; set; }
        public StripFactorySchedule StripFactorySchedule { get; set; }
    }
}
