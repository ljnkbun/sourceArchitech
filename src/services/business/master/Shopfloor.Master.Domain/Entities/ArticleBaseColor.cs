using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ArticleBaseColor : BaseEntity
    {
        public int ArticleId { get; set; }
        public int? WFXColorId { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public virtual Article Article { get; set; }
    }
}
