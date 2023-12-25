namespace Shopfloor.Master.Application.Settings
{
    public record WfxArticleApiSettings
    {
        public int IntervalSecond { get; set; }
        public string Uri { get; set; }
        public bool? Enable { get; set; }
    }
}
