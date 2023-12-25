using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingArticles
{
    public class WeavingArticleParameter : RequestParameter
    {
        public int? WeavingIEDId { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public bool? Deleted { get; set; }
    }
}
