using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.ExportDetails
{
    public class ExportDetailParameter : RequestParameter
    {
        public int? ExportArticleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ItemStatus? Status { get; set; }
    }
}
