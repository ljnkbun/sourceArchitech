using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.RequestArticleOutputs
{
    public class RequestArticleOutputModel : BaseModel
    {
        public int RequestDivisionProcessId { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string BaseColorList { get; set; }
        public Status Status { get; set; }
    }
}
