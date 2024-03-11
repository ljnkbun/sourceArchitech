using Shopfloor.Core.Models.Entities;
using Shopfloor.Production.Domain.Enums;

namespace Shopfloor.Production.Domain.Entities
{
    public class ProductionOutput : BaseEntity
    {
        public int? QCDefinitionId { get; set; }
        public int? FPPOOutputId { get; set; }
        public int? AttachmentId { get; set; }
        public string Code { get; set; }
        public string Remarks { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? WFXExportDate { get; set; }
        public WFXExportStatus? WFXExportStatus { get; set; }
        public SaveStatus? Status { get; set; }
        public string StockMovementNo { get; set; }
        public decimal CaptureMeter { get; set; }
        public decimal ActualWeight { get; set; }
        public int TotalDefect { get; set; }
        public int TotalContDefect { get; set; }
        public int TotalPoint { get; set; }
        public int PointSquareMeter { get; set; }
        public int? WarpDensity { get; set; }
        public int? WeftDensity { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public bool SystemResult { get; set; }
        public bool UserResult { get; set; }
        public bool Result { get; set; }
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual ICollection<InspectionBySize> InspectionBySizes { get; set; }
        public virtual ICollection<DefectCapturing> DefectCapturings { get; set; }
        public virtual ICollection<DefectCapturing4Points> DefectCapturing4Points { get; set; }
        public virtual ICollection<DefectCapturing100Points> DefectCapturing100Points { get; set; }
        public virtual ICollection<DefectCapturingStandard> DefectCapturingStandards { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
