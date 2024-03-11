using Shopfloor.Core.Models.Entities;
using Shopfloor.Production.Application.Models.FPPOOutputDetails;

namespace Shopfloor.Production.Application.Models.FPPOOutputs
{
    public class FPPOOutputModel : BaseModel
    {
        public int? WFXArticleId { get; set; }
        public int? FPPOId { get; set; }
        public string FPPONo { get; set; }
        public string OCNo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public int? PORId { get; set; }
        public string PORNo { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public int? OperationId { get; set; }
        public string OperationCode { get; set; }
        public string OperationName { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public int? QCDefinationId { get; set; }
        public string QCName { get; set; }
        public string UOM { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public virtual ICollection<FPPOOutputDetailModel> FPPODetails { get; set; }
    }
}
