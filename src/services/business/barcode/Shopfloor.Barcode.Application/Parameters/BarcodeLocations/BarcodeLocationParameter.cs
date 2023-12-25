using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.BarcodeLocations
{
    public class BarcodeLocationParameter : RequestParameter
    {
        public int? LocationId { get; set; }
        public int? ArticleBarcodeId { get; set; }
    }
}
