using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ImportDetails
{
    public class ImportDetailModel:BaseModel
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public decimal? Quantity { get; set; }
        public string UOM { get; set; }
        public string Unit { get; set; }
        public ItemStatus? Status { get; set; }
        public string Shade { get; set; }
        public string OC { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? NumberOfCone { get; set; }
        public decimal? WeightPerCone { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
        public int AriticleBarcodeId { get; set; }

    }
}
