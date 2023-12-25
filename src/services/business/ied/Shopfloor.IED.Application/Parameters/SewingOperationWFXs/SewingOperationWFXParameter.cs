using Shopfloor.Core.Models.Parameters;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Parameters.SewingOperationWFXs
{
    public class SewingOperationWFXParameter : RequestParameter
    {
        public int? RequestDivisionProcessId { get; set; }
        public int? CurrentVersionId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string Buyer { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public int? ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public Status? Status { get; set; }
        public bool? Deleted { get; set; }
    }
}
