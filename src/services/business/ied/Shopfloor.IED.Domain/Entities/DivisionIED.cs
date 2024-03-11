using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public abstract class DivisionIED : BaseEntity
    {
        public string RequestNo { get; set; }
        public int RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Buyer { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string AnalysisUser { get; set; }
        public Status Status { get; set; }
        public string RejectReason { get; set; }
        public bool Deleted { get; set; }
    }
}
