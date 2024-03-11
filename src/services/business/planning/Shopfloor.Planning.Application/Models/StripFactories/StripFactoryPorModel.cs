using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.StripFactories
{
    public class StripFactoryPorModel : BaseModel
    {
        public int StripFactoryId { get; set; }
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
        public int? BOMId { get; set; }
        public string BOMNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal RemainingQuantity { get; set; }
        public PORStatus? Status { get; set; }
        public OCStatus? OCStatus { get; set; }
        public string Type { get; set; }
        public bool IsAllocated { get; set; }
        public string ProcessName { get; set; }
    }
}
