using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Planning.Domain.Entities
{
    public class FPPO : BaseEntity
    {
        public int StripScheduleId { get; set; }
        public int? WFXFPPOId { get; set; }
        public string FPPONo { get; set; }
        public int? WFXOCId { get; set; }
        public string OCNo { get; set; }
        public string WFXDeliveryOrderCode { get; set; }
        public string Supplier { get; set; }
        public string WipDispatchSite { get; set; }
        public string WipReceivingSite { get; set; }
        public int PORId { get; set; }
        public string PORNo { get; set; }
        public string BatchNo { get; set; }
        public string JobOrderNo { get; set; }
        public int? FactoryId { get; set; }
        public int? LineId { get; set; }
        public int? MachineId { get; set; }
        public int? ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? WFXArticleId { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string UOM { get; set; }
        public bool WFXSynced { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<FPPODetail> FPPODetails { get; set; }
        public virtual StripSchedule StripSchedule { get; set; }
    }
}
