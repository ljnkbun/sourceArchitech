using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCRequest : BaseEntity
    {
        public QCRequest()
        {
            QCRequestArticles = new HashSet<QCRequestArticle>();
        }
		public DateTime QCRequestDate { get; set; }
		public string SiteCode { get; set; }
		public string SiteName { get; set; }
		public string SupplierName { get; set; }
		public string QCRequestNo { get; set; }
		public string Category { get; set; }
		public QCRequestStatus QCRequestStatus { get; set; }
		public TransferStatus TransferStatus { get; set; }
		public string DocumentNo { get; set; }
		public string QCDefinitionCode { get; set; }
		public decimal RequestedQty { get; set; }
		public string ProductionOutputCode { get; set; }
        public virtual ICollection<QCRequestArticle> QCRequestArticles { get; set; }
    }
}
