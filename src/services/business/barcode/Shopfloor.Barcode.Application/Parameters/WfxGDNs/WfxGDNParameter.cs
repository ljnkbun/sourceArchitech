using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.WfxGDNs
{
    public class WfxGDNParameter : RequestParameter
    {
        public ExportTypes? GDNTypes { get; set; }
        public string GDNType { get; set; }
        public DateTime? FromOrderDate { get; set; }
        public DateTime? ToOrderDate { get; set; }
        public string GDNNum { get; set; }
        public string SupplierName { get; set; }
        public string WFXArticleCode { get; set; }

    }
}
