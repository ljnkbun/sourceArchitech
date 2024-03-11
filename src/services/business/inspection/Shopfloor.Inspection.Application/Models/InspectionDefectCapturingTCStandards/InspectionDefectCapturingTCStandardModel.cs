using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Application.Models.InspectionDefectCapturingTCStandards
{
    public class InspectionDefectCapturingTCStandardModel : BaseModel
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
        public string QCDefectCode { get; set; }
        public string QCDefectNameVN { get; set; }
        public string QCDefectNameEN { get; set; }
        public int? ParrentId { get; set; }
        public int? Level { get; set; }
    }
}
