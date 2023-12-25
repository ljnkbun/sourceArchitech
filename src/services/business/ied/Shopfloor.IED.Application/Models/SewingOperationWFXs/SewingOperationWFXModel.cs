using Shopfloor.Core.Models.Entities;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Models.SewingOperationWFXs
{
    public class SewingOperationWFXModel : BaseModel
    {
        public int RequestDivisionProcessId { get; set; }
        public int? CurrentVersionId { get; set; }
        public string WFXProcessCode { get; set; }
        public string WFXProcessName { get; set; }
        public string Buyer { get; set; }
        public string ProductGroup { get; set; }
        public string ProductSubCategory { get; set; }
        public int ArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public decimal SMV { get; set; }
        public decimal AllowedTime { get; set; }
        public decimal FactoryTime { get; set; }
        public decimal LabourCostOp { get; set; }
        public decimal LabourCostFactory { get; set; }
        public decimal FactoryOverheadAgainstLabourPercent { get; set; }
        public decimal LabourCostFactoryIncludingOverhead { get; set; }
        public Status Status { get; set; }
        public bool Deleted { get; set; }
        public ICollection<SewingSubOperationWFXModel> SewingSubOperationWFXs { get; set; }
    }
}
