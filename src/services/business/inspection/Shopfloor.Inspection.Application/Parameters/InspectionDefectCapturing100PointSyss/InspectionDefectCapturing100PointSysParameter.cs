using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing100PointSyss
{
    public class InspectionDefectCapturing100PointSysParameter : RequestParameter
    {
        public int? Inpection100PointSysId { get; set; }
		public int? QCDefectId { get; set; }
		public int? Minor { get; set; }
		public int? Major { get; set; }
		public int? Critial { get; set; }
		public int? AttachmentId { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
		public string Remark { get; set; }
    }
}
