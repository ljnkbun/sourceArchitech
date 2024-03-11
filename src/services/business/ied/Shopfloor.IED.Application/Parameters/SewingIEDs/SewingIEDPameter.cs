using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.SewingIEDs
{
    public class SewingIEDParameter : RequestParameter
    {
        public string RequestNo { get; set; }
        public int? RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Buyer { get; set; }
        public string StyleRef { get; set; }
        public string ProductGroup { get; set; }
        public string SubCategory { get; set; }
        public string Description { get; set; }
        public decimal? SMV { get; set; }
        public decimal? AllowedTime { get; set; }
        public decimal? FactoryTime { get; set; }
        public decimal? LabourCostOp { get; set; }
        public decimal? LabourCostFactory { get; set; }
        public decimal? FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal? LabourCostFactoryIncludingOverhead { get; set; }
        public string Comment { get; set; }
        public DateTime? AnalysisDate { get; set; }
        public string AnalysisUser { get; set; }
        public Status? Status { get; set; }
        public string RejectReason { get; set; }
        public bool? Deleted { get; set; }
    }
}
