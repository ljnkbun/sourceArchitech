using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.QCRequests
{
    public class QCRequestModel : BaseModel
    {
        public int QCRequestId { get; set; }
        public DateTime? QCRequestDate { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string SupplierName { get; set; }
        public string QCRequestNo { get; set; }
        public string Category { get; set; }
        public QCRequestStatus? QCRequestStatus { get; set; }
        public TransferStatus? TransferStatus { get; set; }
        public string DocumentNo { get; set; }
        public string QCDefinitionCode { get; set; }
        public decimal? RequestedQty { get; set; }

        // QCRequestArticleModel
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Shade { get; set; }
        public string Lot { get; set; }
        public string StyleNo { get; set; }
        public string StyleName { get; set; }
        public string Season { get; set; }
        public string Buyer { get; set; }
        public string FPONo { get; set; }
        public string Location { get; set; }
        public string UOM { get; set; }
        public string OCNo { get; set; }
        public string GRNNo { get; set; }
        public string PONo { get; set; }
        public DateTime? GRNDate { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public decimal QCReleasedQty { get; set; }
        public decimal GRNQty { get; set; }
        public string ProductionOutputCode { get; set; }
    }
}
