using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Production.Application.Parameters.DefectCapturingStandards
{
    public class DefectCapturingStandardParameter : RequestParameter
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int Defect { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public string RootCauseIds { get; set; }
        public string CorrectiveActionIds { get; set; }
        public int? TimelineId { get; set; }
        public string PersonInChargeIds { get; set; }
    }
}
