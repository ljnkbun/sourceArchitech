using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Domain.Entities
{
    public class DefectCapturingStandard : BaseEntity
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int Defect { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public string RootCauseIds { get; set; }
        public string CorrectiveActionIds { get; set; }
        public int? TimelineId { get; set; }
        public string PersonInChargeIds { get; set; }
        public virtual ProductionOutput ProductionOutput { get; set; }
        public virtual Attachment Attachment { get; set; }

    }
}
