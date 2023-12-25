using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.WfxPOArticles
{
    public class WfxPOArticleParameter : RequestParameter
    {
        public OrderTypes? OrderTypes { get; set; } = Domain.Enums.OrderTypes.PO;
        public string OrderType { get; set; } = Domain.Enums.OrderTypes.PO.ToString();
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public string OrderRefNum { get; set; }
        public string SupplierName { get; set; }
        public string WFXArticleCode { get; set; }
        public ArticleTypes? ArticleTypes { get; set; }
        public string ArticleType { get; set; }

    }
}
