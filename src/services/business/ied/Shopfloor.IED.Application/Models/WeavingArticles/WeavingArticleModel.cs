using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingArticles
{
    public class WeavingArticleModel : BaseModel
    {
        public int WeavingIEDId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool Deleted { get; set; }
    }
}
