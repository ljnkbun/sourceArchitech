using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingOperationInputArticles
{
    public class WeavingOperationInputArticleModel : BaseModel
    {
        public int WeavingOperationId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
}
