using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Planning.Application.Parameters.StripFactories
{
    public class StripFactoryParameter : RequestParameter
    {
        public int? PlanningGroupFactoryId { get; set; }
        public int? PORId { get; set; }
        public int? ProcessId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RemainningQuantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsPlanning { get; set; }
        public bool? IsAllocated { get; set; }
        public bool? IsSplitBatch { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Buyer { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductGroup { get; set; }
        public string JobOrderNo { get; set; }
        public string BatchNo { get; set; }
    }
}
