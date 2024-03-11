using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class WfxGDI : BaseEntity
    {
        public string GDINum { get; set; }
        public DateTime? GDICreationDate { get; set; }
        public string GDIType { get; set; }
        public string OrderRefNum { get; set; }
        public DateTime? OrderCreationDate { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string BuyerStyleRef { get; set; }
        public string RollNo { get; set; }
        public string RollBarcode { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string RollOCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public decimal? GDIPendingUnits { get; set; }
        public decimal? RollUnits { get; set; }
        public virtual ICollection<WfxGDIHistory> WfxGDIHistories { get; set; }

    }

}
