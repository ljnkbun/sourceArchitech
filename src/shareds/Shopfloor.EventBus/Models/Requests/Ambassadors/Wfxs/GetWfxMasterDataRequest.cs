namespace Shopfloor.EventBus.Models.Requests
{
    public class GetWfxMasterDataRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string MetaDataFor { get; set; }
    }
}
