using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class ExportArticle : BaseMasterEntity
    {
        public ExportArticle()
        {
            ExportDetails = new HashSet<ExportDetail>();
        }
        public int ArticleId { get; set; }
        public int ExportId { get; set; }
        public string GDINo { get; set; }
        public ExportTypes? GDIType { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string UOM { get; set; }
        public decimal? Quantity { get; set; }
        public string FromSite { get; set; }
        public string Buyer { get; set; }
        public string SummaryOC { get; set; }
        public string DeliveryOC { get; set; }
        public string LotNo { get; set; }
        public string Note { get; set; }
        public ItemStatus? Status { get; set; }

        public virtual Export Export { get; set; }

        public virtual ICollection<ExportDetail> ExportDetails { get; set; }
    }

}
