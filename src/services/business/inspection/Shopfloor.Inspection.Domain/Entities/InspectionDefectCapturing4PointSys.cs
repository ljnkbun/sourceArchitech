using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InspectionDefectCapturing4PointSys : BaseEntity
    {
        public InspectionDefectCapturing4PointSys()
        {
            InspectionDefectError4PointSyss = new HashSet<InspectionDefectError4PointSys>();
        }
        public int Inpection4PointSysId { get; set; }
        public int QCDefectId { get; set; }
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
        public virtual Inpection4PointSys Inpection4PointSys { get; set; }
        public virtual ICollection<InspectionDefectError4PointSys> InspectionDefectError4PointSyss { get; set; }
    }
}
