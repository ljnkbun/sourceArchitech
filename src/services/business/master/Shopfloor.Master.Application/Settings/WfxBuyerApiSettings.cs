namespace Shopfloor.Master.Application.Settings
{
    public record WfxBuyerApiSettings
    {
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
}
