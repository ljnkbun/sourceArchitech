using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class ArticleBarcodeHistory : BaseEntity
    {
        public ArticleBarcodeHistory()
        {
        }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public MergeSplitType? MergeSplitType { get; set; }
    }
}
