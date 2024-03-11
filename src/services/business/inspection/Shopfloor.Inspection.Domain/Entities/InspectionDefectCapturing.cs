using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InspectionDefectCapturing : BaseEntity
    {
        public InspectionDefectCapturing()
        {
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public int Minor { get; set; }
        public int Major { get; set; }
        public int Critial { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public int InspectionId { get; set; }
        public int QCDefectId { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}
