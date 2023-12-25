using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ExportArticles
{
    public class ExportArticleModel : BaseModel
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string SourceASNNo { get; set; }
        public string Supplier { get; set; }
        public string Buyer { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }
    }
}
