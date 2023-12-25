using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingRouting : BaseEntity
    {
        public int WeavingArticleId { get; set; }
        public int LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingOperation { get; set; }
        public string MachineType { get; set; }
        public bool Deleted { get; set; }
        public virtual WeavingArticle WeavingArticle { get; set; }
    }
}
