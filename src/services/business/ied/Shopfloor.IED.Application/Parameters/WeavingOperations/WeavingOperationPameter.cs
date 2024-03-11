using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.WeavingOperations
{
    public class WeavingOperationParameter : RequestParameter
    {
        public int? WeavingRoutingId { get; set; }
        public int? LineNumber { get; set; }
        public int OperationId { get; set; }
        public string Operation { get; set; }
        public string MachineType { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
    }
}
