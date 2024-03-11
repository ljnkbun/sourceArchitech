using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturingTCStandards
{
    public class InspectionDefectCapturingTCStandardParameter : RequestParameter
    {
        public int? InpectionTCStandardId { get; set; }
		public int? QCDefectId { get; set; }
		public int? Defect { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
    }
}
