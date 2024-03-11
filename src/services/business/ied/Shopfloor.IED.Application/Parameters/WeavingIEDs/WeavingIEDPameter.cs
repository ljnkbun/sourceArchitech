using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingIEDs
{
    public class WeavingIEDParameter : RequestParameter
    {
        public int? RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string RequestNo { get; set; }
        public int? RequestTypeId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Buyer { get; set; }
        public string Comment { get; set; }
        public Status? Status { get; set; }
        public string RejectReason { get; set; }
        public bool? Deleted { get; set; }
    }
}
