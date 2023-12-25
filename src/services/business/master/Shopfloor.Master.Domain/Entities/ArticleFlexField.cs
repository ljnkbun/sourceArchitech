using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ArticleFlexField : BaseEntity
    {
        public int ArticleId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

        public virtual Article Article { get; set; }
    }
}
