using Shopfloor.Core.Definations;

namespace Shopfloor.EventBus.Models.Responses.ProductionOutputs
{
    public class GetGRNDetailByCodeResponse
    {

        public virtual ICollection<InspectionBySizeDto> InspectionBySizes { get; set; }
        public virtual ICollection<DefectCapturingDto> DefectCapturings { get; set; }
        public virtual ICollection<DefectCapturing4PointsDto> DefectCapturing4Points { get; set; }
        public virtual ICollection<DefectCapturing100PointsDto> DefectCapturing100Points { get; set; }
        public virtual ICollection<DefectCapturingStandardDto> DefectCapturingStandards { get; set; }
        public virtual ICollection<MesurementDto> Mesurements { get; set; }
    }

    public class InspectionBySizeDto
    {
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string Shade { get; set; }
        public string Lot { get; set; }
        public decimal GRNQty { get; set; }
        public decimal PreInspectedQty { get; set; }
        public decimal LotQty { get; set; }
        public decimal InspectionQty { get; set; }
        public decimal ActualQty { get; set; }
        public int NoOfDefect { get; set; }
        public decimal OKQty { get; set; }
        public decimal BGroupQty { get; set; }
        public decimal BGroupUsable { get; set; }
        public decimal RejectedQty { get; set; }
        public decimal ExcessShortageQty { get; set; }
        public string ReasonforBGroup { get; set; }
        public int? QCRequestDetailId { get; set; }
    }

    public class DefectCapturingDto
    {
        public int Minor { get; set; }
        public int Major { get; set; }
        public int Critial { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public int QCDefinitionDefectId { get; set; }
    }

    public class DefectCapturing4PointsDto
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
        public virtual AttachmentDto Attachment { get; set; }
    }

    public class DefectCapturing100PointsDto
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int? AttachmentId { get; set; }

        public int? Minor { get; set; }
        public int? Major { get; set; }
        public int? Critial { get; set; }
        public string Remark { get; set; }

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
        public virtual AttachmentDto Attachment { get; set; }
    }

    public class DefectCapturingStandardDto
    {
        public int? ProductionOutputId { get; set; }
        public int? QCDefectId { get; set; }
        public int Defect { get; set; }
        public int? AttachmentId { get; set; }
        public string Remark { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public virtual AttachmentDto Attachment { get; set; }
    }

    public class MesurementDto
    {
        public int Minor { get; set; }
        public int Major { get; set; }
        public int Critial { get; set; }
        public int? ProblemRootCauseId { get; set; }
        public int? ProblemCorrectiveActionId { get; set; }
        public int? ProblemTimelineId { get; set; }
        public int? PersonInChargeId { get; set; }
        public int QCDefinitionDefectId { get; set; }
    }

    public class AttachmentDto
    {
        public int? ProductionOutputId { get; set; }
        public int? DefectCapturing100PointsId { get; set; }
        public int? DefectCapturing4PointsId { get; set; }
        public int? DefectCapturingStandardId { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public FileType FileType { get; set; }
    }
}
