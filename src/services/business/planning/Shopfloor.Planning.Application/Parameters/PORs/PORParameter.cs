using Shopfloor.Core.Models.Parameters;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Parameters.PORs
{
    public class PORParameter : RequestParameter
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
        public decimal? Quantity { get; set; }
        public decimal? RemainingQuantity { get; set; }
        public PorType? TypePOR { get; set; }
        public bool? IsAllocated { get; set; }
        public string ProcessName { get; set; }
        public int? ProcessId { get; set; }
        public int? FactoryId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsRemaining { get; set; }
        public string UOM { get; set; }
        public int? OrderId { get; set; }
        public string JobOrderNo { get; set; }
    }
}
