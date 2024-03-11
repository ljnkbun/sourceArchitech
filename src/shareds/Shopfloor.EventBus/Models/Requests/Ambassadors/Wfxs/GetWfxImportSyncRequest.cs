namespace Shopfloor.EventBus.Models.Requests
{
    public class GetWfxImportSyncRequest
    {
       public List<GetWfxImportSyncParameter> Parameters { get; set; }
    }
    public class GetWfxImportSyncParameter
    {
        public string OrderRefNum { get; set; }
        public string ArticleCode { get; set; }
        public string SizeCode { get; set; }
        public string ColorCode { get; set; }
        public string OrderType { get; set; }
        public string ReceiptType { get; set; }
    }
}
