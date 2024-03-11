using Shopfloor.Barcode.Application.Models.ImportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.Imports
{
    public class ImportModel : BaseModel
    {
        public string Note { get; set; }
        public ImportStatus? Status { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ImportType? Type { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string PONo { get; set; }
        public string Supplier { get; set; }
        public WfxStatus? WfxStatus { get; set; }
        public ICollection<ImportArticleModel> ImportArticleModels { get; set; }
    }
}
