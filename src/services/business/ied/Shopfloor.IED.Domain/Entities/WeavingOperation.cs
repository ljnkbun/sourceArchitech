using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class WeavingOperation : BaseEntity
    {
        public WeavingOperation()
        {
            WeavingOperationInputArticles = new HashSet<WeavingOperationInputArticle>();
        }

        public int WeavingRoutingId { get; set; }
        public int LineNumber { get; set; }
        public int OperationId { get; set; }
        public string Operation { get; set; }
        public string MachineType { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public virtual WeavingRouting WeavingRouting { get; set; }
        public virtual ICollection<WeavingOperationInputArticle> WeavingOperationInputArticles { get; set; }
    }
}