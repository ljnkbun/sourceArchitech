using Shopfloor.Core.Models.Entities;
using System.Net.Mail;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class Inspection : BaseEntity
    {
		public Inspection() {
            InspectionBySizes = new HashSet<InspectionBySize>();
            InspectionDefectCapturings = new HashSet<InspectionDefectCapturing>();
            InspectionMesurements = new HashSet<InspectionMesurement>();
            Attachments = new HashSet<Attachment>();
        }
        public DateTime InspectionDate { get; set; }
		public int? QCRequestArticleId { get; set; }
		public bool DefaultResult { get; set; }
		public bool UserResult { get; set; }
		public bool MeasurementResult { get; set; }
		public decimal? MeasurementQty { get; set; }
		public decimal? InspectionQty { get; set; }
		public string Reason { get; set; }
		public string Remark { get; set; }
		public string Line { get; set; }
		public decimal TotalDefect { get; set; }
		public string Stage { get; set; }
		public string CuttingTable { get; set; }
		public bool IsCreatedFromProduction { get; set; }
        public virtual ICollection<InspectionBySize> InspectionBySizes { get; set; }
        public virtual ICollection<InspectionDefectCapturing> InspectionDefectCapturings { get; set; }
        public virtual ICollection<InspectionMesurement> InspectionMesurements { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
		public virtual QCRequestArticle QCRequestArticle { get; set; }
    } 
}
