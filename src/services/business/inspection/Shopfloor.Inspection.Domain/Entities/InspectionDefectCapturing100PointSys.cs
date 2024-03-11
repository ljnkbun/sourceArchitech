using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InspectionDefectCapturing100PointSys : BaseEntity
    {
        public InspectionDefectCapturing100PointSys()
        {
            InspectionDefectError100PointSyss = new HashSet<InspectionDefectError100PointSys>();
        }
        public int Inpection100PointSysId { get; set; }
        public int QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critial { get; set; }
        public int? AttachmentId { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public virtual Inpection100PointSys Inpection100PointSys { get; set; }
        public virtual ICollection<InspectionDefectError100PointSys> InspectionDefectError100PointSyss { get; set; }
    }
}
