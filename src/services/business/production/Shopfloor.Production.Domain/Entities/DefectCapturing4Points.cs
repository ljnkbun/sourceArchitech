using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Domain.Entities
{
    public class DefectCapturing4Points : BaseEntity
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int? AttachmentId { get; set; }

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
        public virtual Attachment Attachment { get; set; }

    }
}
