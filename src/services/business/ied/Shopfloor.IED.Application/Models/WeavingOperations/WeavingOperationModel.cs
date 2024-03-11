using Shopfloor.Core.Models.Entities;

namespace Shopfloor.IED.Application.Models.WeavingOperations
{
    public class WeavingOperationModel : BaseModel
    {
        public int WeavingRoutingId { get; set; }
        public int LineNumber { get; set; }
        public int OperationId { get; set; }
        public string Operation { get; set; }
        public string MachineType { get; set; }
        public int WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
}
