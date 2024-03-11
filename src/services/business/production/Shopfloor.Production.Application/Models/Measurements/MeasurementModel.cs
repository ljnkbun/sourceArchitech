using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Application.Models.Measurements
{
    public class MeasurementModel : BaseModel
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critical { get; set; }
        public int? ParentId { get; set; }
        public string RootCauseIds { get; set; }
        public string PersonInChargeIds { get; set; }
        public string CorrectActionIds { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorName { get; set; }
        public int? TimelineId { get; set; }
    }
}
