using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.InspectionDefectCapturing4PointSyss
{
    public class InspectionDefectCapturing4PointSysParameter : RequestParameter
    {
        public int? Inpection4PointSysId { get; set; }
		public int? QCDefectId { get; set; }
		public int? DefectQtyOne { get; set; }
		public int? DefectQtyTwo { get; set; }
		public int? DefectQtyThree { get; set; }
		public int? DefectQtyFour { get; set; }
		public int? MinorOne { get; set; }
		public int? MinorTwo { get; set; }
		public int? MinorThree { get; set; }
		public int? MinorFour { get; set; }
		public int? MajorOne { get; set; }
		public int? MajorTwo { get; set; }
		public int? MajorThree { get; set; }
		public int? MajorFour { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
		public int? AttachmentId { get; set; }
		public string Remark { get; set; }
    }
}
