using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class ImportArticle : BaseEntity
    {
        public ImportArticle()
        {
            ImportDetails = new HashSet<ImportDetail>();
        }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string PONo { get; set; }
        public string GDNNumber { get; set; }
        public string GDNType { get; set; }
        public string Warehouse { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string SupplierName { get; set; }
        public string OrderRefNum { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string SizeCode { get; set; }
        public string UOM { get; set; }
        public ItemStatus? Status { get; set; }
        public decimal? Quantity { get; set; }
        public string OCNum { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public int ImportId { get; set; }
        public Import Import { get; set; }
    }
}
