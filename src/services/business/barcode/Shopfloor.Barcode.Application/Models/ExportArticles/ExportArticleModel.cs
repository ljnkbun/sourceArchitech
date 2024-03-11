using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Application.Models.WfxGDIs;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ExportArticles
{
    public class ExportArticleModel : BaseModel
    {

        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public int ExportId { get; set; }
        public string GDINum { get; set; }
        public string OrderRefNum { get; set; }
        public ExportTypes? GDIType { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string FromSite { get; set; }
        public string Buyer { get; set; }
        public string SummaryOC { get; set; }
        public string DeliveryOC { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }

        public ICollection<ExportDetailModel> ExportDetailModels { get; set; }
    }
}
