using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.Articles
{
    public class ArticleModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
