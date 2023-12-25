using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.RequestArticleInputs
{
    public class RequestArticleInputModel : BaseModel
    {
        public int RequestArticleOutputId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
}
