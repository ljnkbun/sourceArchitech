using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.BarcodeLocations
{
    public class BarcodeLocationModel : BaseModel
    {
        public int? LocationId { get; set; }
        public int? ArticleBarcodeId { get; set; }
    }
}
