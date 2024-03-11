using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.WfxGDIs
{
    public class WfxGDIMasterModel : BaseModel
    {
        public string GDINum { get; set; }
        public DateTime? GDICreationDate { get; set; }
        public string GDIType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string ColorName { get; set; }
        public string Size { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string No { get; set; }
        public string Barcode { get; set; }
        public string ParentBarcode { get; set; }
        public string UOM { get; set; }
        public string OCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string Site { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public decimal? RemainQuantity { get; set; }
        public decimal? Quantity { get; set; }
    }
}

