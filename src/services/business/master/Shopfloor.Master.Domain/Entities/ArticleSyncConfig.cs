using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Master.Domain.Entities
{
    public class ArticleSyncConfig : BaseEntity
    {
        public bool? Enable { get; set; }
        public string Category { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? ModifiedFrom { get; set; }
    }
}
