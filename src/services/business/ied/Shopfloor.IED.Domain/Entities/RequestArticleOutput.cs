using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestArticleOutput : BaseEntity
    {
        public RequestArticleOutput()
        {
            RequestArticleInputs = new HashSet<RequestArticleInput>();
        }
        public int RequestDivisionProcessId { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public virtual RequestDivisionProcess RequestDivisionProcess { get; set; }
        public virtual ICollection<RequestArticleInput> RequestArticleInputs { get; set; }
    }
}
