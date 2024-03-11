using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class Export : BaseMasterEntity
    {
        public Export()
        {
            ExportArticles = new HashSet<ExportArticle>();
        }
        public string Note { get; set; }
        public ExportTypes? GDIType { get; set; }
        public ExportStatus? Status { get; set; }
        public WfxStatus? WfxStatus { get; set; }
        public virtual ICollection<ExportArticle> ExportArticles { get; set; }
    }

}
