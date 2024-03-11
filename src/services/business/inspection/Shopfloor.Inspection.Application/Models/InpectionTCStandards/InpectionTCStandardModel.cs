using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Application.Models.InspectionDefectCapturingTCStandards;
using Shopfloor.Inspection.Application.Models.QCDefinitions;
using Shopfloor.Inspection.Application.Models.QCRequestArticles;

namespace Shopfloor.Inspection.Application.Models.InpectionTCStandards
{
    public class InpectionTCStandardModel : BaseModel
    {
        public int? QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public string Grade { get; set; }
        public bool? Result { get; set; }
        public int? PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public bool? IsCreatedFromProduction { get; set; }
        public DateTime? InspectionDate { get; set; }
        public QCRequestArticleModel QCRequestArticle { get; set; }
        public QCDefinitionModel QCDefinition { get; set; }
        public ICollection<InspectionDefectCapturingTCStandardModel> InspectionDefectCapturingTCStandards { get; set; }
    }
}
