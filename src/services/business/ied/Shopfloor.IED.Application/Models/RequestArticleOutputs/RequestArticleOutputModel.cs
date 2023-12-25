using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.RequestArticleOutputs
{
    public class RequestArticleOutputModel : BaseModel
    {
        public int RequestDivisionProcessId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
    }
}
