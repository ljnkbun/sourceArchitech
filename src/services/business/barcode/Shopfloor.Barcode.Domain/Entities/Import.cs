using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class Import : BaseMasterEntity
    {
        public Import()
        {
            ImportArticles = new HashSet<ImportArticle>();
        }
        public string Note { get; set; }
        public ImportStatus? Status { get; set; }
        public ImportType? Type { get; set; }
        public virtual ICollection<ImportArticle> ImportArticles { get; set; }

    }
}
