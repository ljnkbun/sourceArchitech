using Shopfloor.Core.Models.Entities;
using Shopfloor.Production.Domain.Enums;

namespace Shopfloor.Production.Application.Models.ProductionOutputs
{
    public class ProductionOutputModel : BaseModel
    {
        public int? QCDefinitionId { get; set; }
        public int? FPPOOutputId { get; set; }
        public int? AttachmentId { get; set; }
        public string Code { get; set; }
        public string OCNo { get; set; }
        public string FPPONo { get; set; }
        public string Group { get; set; }
        public string Line { get; set; }
        public string OperationName { get; set; }
        public decimal? UpdateToDate { get; set; }
        public decimal? Balance { get; set; }
        public decimal? FRUpdateToDate { get; set; }
        public decimal? FRBalance { get; set; }
        public decimal? Strip { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public DateTime? InputDate { get; set; }
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
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }
    }
}
