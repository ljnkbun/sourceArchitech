using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.InspectionDefectError4PointSyss;

namespace Shopfloor.Inspection.Application.Models.InspectionDefectCapturing4PointSyss
{
    public class InspectionDefectCapturing4PointSysModel : BaseModel
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
        public string Remark { get; set; }
        public string QCDefectCode { get; set; }
        public string QCDefectNameVN { get; set; }
        public string QCDefectNameEN { get; set; }
        public int? ParrentId { get; set; }
        public int? Level { get; set; }
        public ICollection<InspectionDefectError4PointSysModel> InspectionDefectError4PointSyss { get; set; }
    }
}
