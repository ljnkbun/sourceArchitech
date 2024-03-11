using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.Attachments;
using Shopfloor.Inspection.Application.Models.InspectionBySizes;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturings;
using Shopfloor.Inspection.Application.Models.InspectionMesurements;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Application.Models.QCRequestArticles;

namespace Shopfloor.Inspection.Application.Models.Inspections
{
    public class InspectionModel : BaseModel
    {
        public DateTime? InspectionDate { get; set; }
        public int? QCRequestArticleId { get; set; }
        public bool? DefaultResult { get; set; }
        public bool? UserResult { get; set; }
        public bool? MeasurementResult { get; set; }
        public decimal? MeasurementQty { get; set; }
        public decimal? InspectionQty { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
        public string Line { get; set; }
        public decimal? TotalDefect { get; set; }
        public string Stage { get; set; }
        public string CuttingTable { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public ICollection<InspectionBySizeModel> InspectionBySizes { get; set; }
        public ICollection<InspectionMesurementModel> InspectionMesurements { get; set; }
        public ICollection<InspectionDefectCapturingModel> InspectionDefectCapturings { get; set; }
        public ICollection<AttachmentModel> Attachments { get; set; }

        public QCRequestArticleModel QCRequestArticle { get; set; }
        public QCDefinitionModel QCDefinition { get; set; }
    }
}
