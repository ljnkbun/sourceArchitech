using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingOperationInputArticle : BaseEntity
    {
        public int WeavingOperationId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public virtual WeavingOperation WeavingOperation { get; set; }
    }
}