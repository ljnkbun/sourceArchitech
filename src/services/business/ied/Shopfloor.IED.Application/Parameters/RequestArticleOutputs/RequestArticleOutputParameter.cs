using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RequestArticleOutputs
{
    public class RequestArticleOutputParameter : RequestParameter
    {
        public int? RequestDivisionProcessId { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
    }
}
