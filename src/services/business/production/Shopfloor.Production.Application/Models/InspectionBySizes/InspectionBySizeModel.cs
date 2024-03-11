using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Production.Application.Models.InspectionBySizes
{
    public class InspectionBySizeModel : BaseModel
    {
        public int? ProductionOutputId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string LotNo { get; set; }
        public string Shade { get; set; }
        public string UOM { get; set; }
        public decimal? Balance { get; set; }
        public decimal? FPPOQty { get; set; }
        public decimal? UpdatedToDate { get; set; }
        public decimal? OKQty { get; set; }
        public decimal? BGroupQty { get; set; }
        public decimal? RejectQty { get; set; }
    }
}
