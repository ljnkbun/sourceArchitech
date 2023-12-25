using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Barcode.Application.Models.ImportTransferToSiteSyncs
{
    public class ImportTransferToSiteSyncModel : BaseModel
    {
        public string ArticleName { get; set; }
        public string ArticleCode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int? Qty { get; set; }
        public string UOM { get; set; }
        public string StoringUOM { get; set; }
        public string GDNNo { get; set; }
        public string FromSite { get; set; }
        public string ToSite { get; set; }
        public string OC { get; set; }
        public string LotNo { get; set; }
    }
}
