namespace Shopfloor.EventBus.Models.Requests
{
    public class GetWfxPOArticleRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> SearchDics { get; set; }
    }
}
