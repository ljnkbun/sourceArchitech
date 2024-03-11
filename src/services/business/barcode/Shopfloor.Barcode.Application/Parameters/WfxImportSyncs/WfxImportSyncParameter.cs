using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.WfxImportSyncs
{
    public class WfxImportSyncParameter : RequestParameter
    {
        public string OrderRefNum { get; set; }
        public string ArticleCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string OrderType { get; set; }
        public string ReceiptType { get; set; }

    }
}
