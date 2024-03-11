using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Domain.Entities
{
    public class DefectCapturing : BaseEntity
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critical { get; set; }
        public int? ParentId { get; set; }

        public bool? IsLongError { get; set; }
        public decimal? LongErrorFrom { get; set; }
        public decimal? LongErrorTo { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorName { get; set; }
        public string RootCauseName { get; set; }
        public string PersonInChargeName { get; set; }
        public string CorrectActionName { get; set; }

        public string CorrectActionIds { get; set; }
        public string PersonInChargeIds { get; set; }
        public string RootCauseIds { get; set; }
        public int? TimelineId { get; set; }
        public virtual ProductionOutput ProductionOutput { get; set; }

    }
}
