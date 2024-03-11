using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripFactorySchedule : BaseEntity
    {
        public StripFactorySchedule()
        {
            StripFactoryScheduleDetails = new HashSet<StripFactoryScheduleDetail>();
        }
        public int StripFactoryId { get; set; }
        public int? StripScheduleId { get; set; }
        public decimal Quantity { get; set; }
        public string BatchNo { get; set; }
        public StripSchedule StripSchedule { get; set; }
        public StripFactory StripFactory { get; set; }
        public virtual ICollection<StripFactoryScheduleDetail> StripFactoryScheduleDetails { get; set; }
    }
}
