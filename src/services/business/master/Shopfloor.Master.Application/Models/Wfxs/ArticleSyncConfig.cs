namespace Shopfloor.Master.Application.Models.Wfxs
{
    public class ArticleSyncConfig
    {
        public bool? Enable { get; set; }
        public string Category { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? ModifiedFrom { get; set; }
    }
}
