using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Application.Models.ArticleFlexFields
{
    public class ArticleFlexFieldModel : BaseModel
    {
        public string Code { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
    }
}
