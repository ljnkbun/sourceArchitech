using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.IED.Application.Parameters.RequestArticleInputs
{
    public class RequestArticleInputParameter : RequestParameter
    {
        public int? RequestArticleOutputId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
}
