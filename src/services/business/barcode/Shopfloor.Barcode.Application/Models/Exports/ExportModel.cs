using Shopfloor.Barcode.Application.Models.ExportArticles;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.Exports
{
    public class ExportModel : BaseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public ExportStatus? Status { get; set; }
        public ExportTypes? Type { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string GDINo { get; set; }
        public string Buyer { get; set; }
        public WfxStatus? WfxStatus { get; set; }
        public ICollection<ExportArticleModel> ExportArticleModels { get; set; }

    }
}
