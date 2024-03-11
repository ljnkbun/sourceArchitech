using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.InspectionDefectError100PointSyss;

namespace Shopfloor.Inspection.Application.Models.InspectionDefectCapturing100PointSyss
{
    public class InspectionDefectCapturing100PointSysModel : BaseModel
    {
        public int? Inpection100PointSysId { get; set; }
        public int? QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critial { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public string QCDefectCode { get; set; }
        public string QCDefectNameVN { get; set; }
        public string QCDefectNameEN { get; set; }
        public int? ParrentId { get; set; }
        public int? Level { get; set; }
        public ICollection<InspectionDefectError100PointSysModel> InspectionDefectError100PointSyss { get; set; }
    }
}
