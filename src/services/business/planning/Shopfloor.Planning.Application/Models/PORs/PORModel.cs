using Shopfloor.Core.Models.Entities;
using Shopfloor.Planning.Application.Models.PORDetails;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Models.PORs
{
    public class PORModel : BaseModel
    {
        public int? WfxOCId { get; set; }
        public string OCNo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? WfxPORId { get; set; }
        public string PORNo { get; set; }
        public string DivisionName { get; set; }
        public int? DivisionId { get; set; }
        public int? WfxArticleId { get; set; }
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
        public PorType? TypePOR { get; set; }
        public bool IsAllocated { get; set; }
        public string ProcessName { get; set; }
        public int? ProcessId { get; set; }
        public string FromPor { get; set; }
        public string ToPor { get; set; }
        public string UOM { get; set; }
        public int? OrderId { get; set; }
        public string JobOrderNo { get; set; }
        public virtual ICollection<PORDetailModel> PORDetails { get; set; }
    }
}
