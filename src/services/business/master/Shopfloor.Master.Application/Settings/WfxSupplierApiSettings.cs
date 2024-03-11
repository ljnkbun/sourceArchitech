namespace Shopfloor.Master.Application.Settings
{
    public record WfxSupplierApiSettings
    {
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
}
