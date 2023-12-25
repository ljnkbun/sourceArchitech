using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.Articles
{
    public class ArticleParameter : RequestParameter
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
