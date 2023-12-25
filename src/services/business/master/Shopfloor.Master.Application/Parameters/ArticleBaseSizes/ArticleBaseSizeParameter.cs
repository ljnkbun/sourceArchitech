using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Master.Application.Parameters.ArticleBaseSizes
{
    public class ArticleBaseSizeParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ArticleId { get; set; }
    }
}
