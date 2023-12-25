using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ExportDetails
{
    public class ExportDetailModel : BaseModel
    {
        public ItemStatus? Status { get; set; }
        public int? ExportArticleId { get; set; }
        public int? ArticleBarcodeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string Note { get; set; }
    }
}
