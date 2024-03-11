using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.RequestArticleOutputs
{
    public class RequestArticleOutputParameter : RequestParameter
    {
        public int? RequestDivisionProcessId { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string BaseColorList { get; set; }
        public Status? Status { get; set; }
    }
}
