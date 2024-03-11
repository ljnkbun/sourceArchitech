using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ArticleBarcodes
{
    public class ArticleBarcodeHistoryModel : BaseModel
    {
        public int FromId { get; set; }
        public int ToId { get; set; }
        public MergeSplitType? MergeSplitType { get; set; }
    }
}
