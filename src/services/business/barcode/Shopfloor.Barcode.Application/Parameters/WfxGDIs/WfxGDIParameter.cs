using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.WfxGDIs
{
    public class WfxGDIParameter : RequestParameter
    {
        public ExportTypes? GDITypes { get; set; }
        public string GDIType { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public string OrderRefNum { get; set; }
        public string SupplierName { get; set; }
        public string WFXArticleCode { get; set; }
        public string WareHouse { get; set; }
        public string GDINum { get; set; }

    }
}
