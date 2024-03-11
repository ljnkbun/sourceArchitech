namespace Shopfloor.Planning.Application.Settings
{
    public class JobPorSettings
    {
        public PorJob PorJob {  get; set; }
    }

    public class PorJob
    {
        public string Category { get; set; }
        public string OcNo { get; set; }
        public string LastDays { get; set; }

        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
}
