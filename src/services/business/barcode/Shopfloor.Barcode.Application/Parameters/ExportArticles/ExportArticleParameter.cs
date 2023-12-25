using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.ExportArticles
{
    public class ExportArticleParameter : RequestParameter
    {
        public int? ExportId { get; set; }
        public int? ArticleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SourceASNNo { get; set; }
        public string Supplier { get; set; }
        public string Buyer { get; set; }
        public ItemStatus? Status { get; set; }

    }
}
