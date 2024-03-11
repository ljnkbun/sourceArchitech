using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class StripFactory : BaseEntity
    {
        public StripFactory()
        {
            StripFactorySchedules = new HashSet<StripFactorySchedule>();
        }
        public int PlanningGroupFactoryId { get; set; }
        public int PORId { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainningQuantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPlanning { get; set; }
        public bool IsAllocated { get; set; }
        public bool IsSplitBatch { get; set; }
        public virtual POR Por { get; set; }
        public virtual ICollection<StripFactorySchedule> StripFactorySchedules { get; set; }
        public virtual ICollection<StripFactoryDetail> StripFactoryDetails { get; set; }
    }
}
