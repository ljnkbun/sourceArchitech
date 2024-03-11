using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Domain.Entities
{
    public class WfxGDN : BaseEntity
    {
        public string GDNNum { get; set; }
        public string GDNType { get; set; }
        public string OrderRefNum { get; set; }
        public string WFXArticleCode { get; set; }
        public DateTime? GDNCreationDate { get; set; }
        public string WFXArticleName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string SizeCode { get; set; }
        public string SizeName { get; set; }
        public string FPPOOCNUm { get; set; }
        public string RollNo { get; set; }
        public string RollBarcode { get; set; }
        public decimal? RollUnits { get; set; }
        public string ParentRollBarcode { get; set; }
        public string UOM { get; set; }
        public string RollOCRefNum { get; set; }
        public string Shade { get; set; }
        public string Location { get; set; }
        public int? LocationId { get; set; }
        public string WareHouse { get; set; }
        public string InternalShade { get; set; }
        public string GDINum { get; set; }
        public virtual ICollection<WfxGDNHistory> WfxGDNHistories { get; set; }

    }

}
