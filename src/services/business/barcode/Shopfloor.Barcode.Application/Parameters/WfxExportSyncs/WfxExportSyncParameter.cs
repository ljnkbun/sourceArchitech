using Shopfloor.Core.Models.Parameters;

namespace Shopfloor.Barcode.Application.Parameters.WfxExportSyncs
{
    public class WfxExportSyncParameter : RequestParameter
    {
        public string OrderRefNum { get; set; }
        public string WFXArticleCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string OrderType { get; set; }
        public string ReceiptType { get; set; }

    }
}
