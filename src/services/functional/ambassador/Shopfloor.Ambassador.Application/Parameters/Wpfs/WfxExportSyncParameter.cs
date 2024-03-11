namespace Shopfloor.Ambassador.Application.Parameters
{
    public class WfxExportSyncParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderRefNum { get; set; }
        public string WFXArticleCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string OrderType { get; set; }
        public string ReceiptType { get; set; }

    }

}
