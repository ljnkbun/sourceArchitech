using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Domain.Entities
{
    public class RequestArticleOutput : BaseEntity
    {
        public RequestArticleOutput()
        {
            RequestArticleInputs = new HashSet<RequestArticleInput>();
        }
        public int RequestDivisionProcessId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string BaseColorList { get; set; }
        public Status Status { get; set; }
        public virtual RequestDivisionProcess RequestDivisionProcess { get; set; }
        public virtual DyeingIED DyeingIED { get; set; }
        public virtual SewingIED SewingIED { get; set; }
        public virtual KnittingIED KnittingIED { get; set; }
        public virtual WeavingIED WeavingIED { get; set; }
        public virtual ICollection<RequestArticleInput> RequestArticleInputs { get; set; }
    }
}
