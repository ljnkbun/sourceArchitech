namespace Shopfloor.Barcode.Application.Settings
{
    public class JobSettings
    {
        public POArticle POArticle { get; set; }
        public GDI GDI { get; set; }
        public GDN GDN { get; set; }
    }

    public class POArticle
    {
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
    public class GDI
    {
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
    public class GDN
    {
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
}
