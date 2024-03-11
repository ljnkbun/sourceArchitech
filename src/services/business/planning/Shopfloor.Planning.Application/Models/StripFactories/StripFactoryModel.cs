using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Models.StripFactories
{
    public class StripFactoryModel : BaseModel
    {
        public int PlanningGroupFactoryId { get; set; }
        public int PORId { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainningQuantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsPlanning { get; set; }
        public bool IsAllocated { get; set; }
        public bool IsSplitBatch { get; set; }

        // POR
        public string OCNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public string BOMNo { get; set; }
        public string FactoryName { get; set; }
        public string ProcessName { get; set; }
        public virtual ICollection<StripFactorySchedule> StripFactorySchedules { get; set; }
    }
}
