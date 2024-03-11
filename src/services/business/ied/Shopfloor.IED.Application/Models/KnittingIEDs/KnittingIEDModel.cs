using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.KnittingIEDs
{
    public class KnittingIEDModel : BaseModel
    {
        public int RequestArticleOutputId { get; set; }
        public string RequestNo { get; set; }
        public string RequestType { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Buyer { get; set; }
        public string Remark { get; set; }
        public Status Status { get; set; }
        public string RejectReason { get; set; }
		public DateTime ExpectedDate { get; set; }
        public decimal? ExpectedQty { get; set; }
        public bool Deleted { get; set; }
    }
}
