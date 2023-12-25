using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestArticleInput : BaseEntity
    {
        public int RequestArticleOutputId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public virtual RequestArticleOutput RequestArticleOutput { get; set; }
    }
}
