namespace Shopfloor.Master.Application.Settings
{
    public record WfxApiSettings
    {
        public int IntervalSecond { get; set; }
        public string Uri { get; set; }
        public bool? Enable { get; set; }
    }
}
