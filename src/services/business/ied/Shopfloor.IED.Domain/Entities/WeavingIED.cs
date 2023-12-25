using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingIED : BaseEntity
    {
        public WeavingIED()
        {
            WeavingArticles = new HashSet<WeavingArticle>();
        }
        public int RequestDivisionId { get; set; }
        public string RequestNo { get; set; }
        public string Comment { get; set; }
        public Status Status { get; set; }
        public bool Deleted { get; set; }
        public virtual RequestDivision RequestDivision { get; set; }
        public virtual ICollection<WeavingArticle> WeavingArticles { get; set; }
    }
}
