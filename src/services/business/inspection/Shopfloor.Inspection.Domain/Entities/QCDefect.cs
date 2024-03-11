using Shopfloor.Core.Models.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Entities
{
    public class QCDefect : BaseMasterEntity
    {
		public QCDefect() {
            QCDefinitionDefects = new HashSet<QCDefinitionDefect>();
        }
        public int QCDefecTypeId { get; set; }
		public int? ParrentId { get; set; }
		public string NameEN { get; set; }
		public int? DivisonId { get; set; }
		public string DivisonName { get; set; }
		public int? ProcessId { get; set; }
		public string ProcessName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string SubCategoryId { get; set; }
		public string SubCategoryName { get; set; }
		public int Level { get; set; }
		public InspectionType InspectionType { get; set; }
        public virtual ICollection<QCDefinitionDefect> QCDefinitionDefects { get; set; }
		public virtual QCDefectType QCDefectType { get; set; }
    }
}
