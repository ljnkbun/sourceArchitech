using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.Attachments;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturing100PointSyss;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Application.Models.QCRequestArticles;

namespace Shopfloor.Inspection.Application.Models.Inpection100PointSyss
{
    public class Inpection100PointSysModel : BaseModel
    {
        public int? QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public decimal? CaptureMeter { get; set; }
        public decimal? ActualWeight { get; set; }
        public int? TotalDefect { get; set; }
        public int? TotalContDefect { get; set; }
        public int? TotalPoint { get; set; }
        public int? PointSquareMeter { get; set; }
        public int? WarpDensity { get; set; }
        public int? WeftDensity { get; set; }
        public int? PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public int? AttachmentId { get; set; }
        public bool? SystemResult { get; set; }
        public bool? UserResult { get; set; }
        public string Grade { get; set; }
        public decimal? WeightGM2 { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public DateTime? InspectionDate { get; set; }
        public ICollection<AttachmentModel> Attachments { get; set; }
        public ICollection<InspectionDefectCapturing100PointSysModel> InspectionDefectCapturing100PointSyss { get; set; }
        public QCRequestArticleModel QCRequestArticle { get; set; }
        public QCDefinitionModel QCDefinition { get; set; }
    }
}
