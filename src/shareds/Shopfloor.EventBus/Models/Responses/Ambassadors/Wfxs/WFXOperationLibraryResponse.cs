namespace Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs
{
    public class WFXOperationLibraryResponse
    {
        public List<WFXOperationLibrary> Data { get; set; }
    }
    public class WFXOperationLibrary
    {
        public decimal? ProcessID { get; set; }
        public string ArticleName { get; set; }
        public decimal? OperationID { get; set; }
        public string Operation { get; set; }
        public string SubOperationID { get; set; }
        public string SubOperation { get; set; }
    }
}
