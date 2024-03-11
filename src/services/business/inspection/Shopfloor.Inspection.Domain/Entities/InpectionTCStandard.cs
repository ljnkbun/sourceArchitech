using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class InpectionTCStandard : BaseEntity
    {
        public InpectionTCStandard()
        {
            InspectionDefectCapturingTCStandards = new HashSet<InspectionDefectCapturingTCStandard>();
            Attachments = new HashSet<Attachment>();
        }
        public int QCRequestArticleId { get; set; }
        public string StockMovementNo { get; set; }
        public string Grade { get; set; }
        public bool Result { get; set; }
        public int PersonInChargeId { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<InspectionDefectCapturingTCStandard> InspectionDefectCapturingTCStandards { get; set; }
        public virtual QCRequestArticle QCRequestArticle { get; set; }
        public bool IsCreatedFromProduction { get; set; }
        public DateTime InspectionDate { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
