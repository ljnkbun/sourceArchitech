using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ArticleBaseSize : BaseEntity
    {
        public int ArticleId { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public virtual Article Article { get; set; }
    }
}
