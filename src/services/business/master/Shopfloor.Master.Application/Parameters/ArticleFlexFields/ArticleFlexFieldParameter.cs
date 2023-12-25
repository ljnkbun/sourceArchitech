using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ArticleFlexFields
{
    public class ArticleFlexFieldParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ArticleId { get; set; }
    }
}
