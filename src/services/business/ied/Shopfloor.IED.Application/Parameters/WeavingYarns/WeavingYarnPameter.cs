using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingYarns
{
    public class WeavingYarnParameter : RequestParameter
    {
        public int? WeavingArticleId { get; set; }
        public int? LineNumber { get; set; }
        public YarnType? YarnType { get; set; }
        public string YarnCode { get; set; }
        public string YarnName { get; set; }
        public decimal? YarnInRappo { get; set; }
        public decimal? YarnRatio { get; set; }
        public decimal? SizingRatio { get; set; }
        public decimal? ScaleRatio { get; set; }
        public decimal? ScrapRatio { get; set; }
        public decimal? Weight { get; set; }
        public bool? Deleted { get; set; }
    }
}
