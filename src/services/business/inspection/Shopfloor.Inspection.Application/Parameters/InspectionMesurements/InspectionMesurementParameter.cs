using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Inspection.Application.Parameters.InspectionMesurements
{
    public class InspectionMesurementParameter : RequestParameter
    {
        public int? Minor { get; set; }
		public int? Major { get; set; }
		public int? Critial { get; set; }
		public int? ProblemRootCauseId { get; set; }
		public int? ProblemCorrectiveActionId { get; set; }
		public int? ProblemTimelineId { get; set; }
		public int? PersonInChargeId { get; set; }
        public int? QCDefectId { get; set; }
        public int? InspectionId { get; set; }
    }
}
