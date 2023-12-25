namespace Shopfloor.EventBus.Models.Requests
{
    public class GetWfxArticleRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Dictionary<string, string> SearchDics { get; set; }
    }
}
