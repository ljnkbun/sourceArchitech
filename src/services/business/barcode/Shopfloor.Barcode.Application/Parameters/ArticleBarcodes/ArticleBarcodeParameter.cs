using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.ArticleBarcodes
{
    public class ArticleBarcodeParameter : RequestParameter
    {
        public string Barcode { get; set; }
        public int? CurrentLocationId { get; set; }
        public int? ParentId { get; set; }
    }
}
