using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Application.Models.InspectionMesurements
{
    public class InspectionMesurementModel : BaseModel
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
        public string QCDefectCode { get; set; }
        public string QCDefectNameVN { get; set; }
        public string QCDefectNameEN { get; set; }
        public int? ParrentId { get; set; }
        public int? Level { get; set; }
        public InspectionType InspectionType { get; set; }
        public string QCDefectTypeCode { get; set; }
        public string QCDefectTypeName { get; set; }
    }
}
