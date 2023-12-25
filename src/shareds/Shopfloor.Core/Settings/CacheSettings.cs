namespace Shopfloor.Core.Settings
{
    public record CacheSettings
    {
        public int SlidingExpiration { get; set; }
    }
}
