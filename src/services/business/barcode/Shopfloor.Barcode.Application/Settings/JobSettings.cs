namespace Shopfloor.Barcode.Application.Settings
{
    public class JobSettings
    {
        public POArticle POArticle { get; set; }
    }
    public class POArticle
    {
        public int IntervalSecond { get; set; }
        public bool? Enable { get; set; }
    }
}
