using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InspectionDefectCapturingTCStandard : BaseEntity
    {
        public int InpectionTCStandardId { get; set; }
		public int QCDefectId { get; set; }
		public int Defect { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
		public virtual InpectionTCStandard InpectionTCStandard { get; set; }
    }
}
