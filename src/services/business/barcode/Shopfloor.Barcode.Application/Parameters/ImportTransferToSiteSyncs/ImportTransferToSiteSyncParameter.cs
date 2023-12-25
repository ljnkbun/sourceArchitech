using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.ImportTransferToSiteSyncs
{
    public class ImportTransferToSiteSyncParameter : RequestParameter
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal? Qty { get; set; }
        public string UOM { get; set; }
        public string GDNNo { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
    }
}
