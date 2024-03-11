namespace Shopfloor.Ambassador.Application.Settings
{
    public record WFXWebSharedAPISetting
    {
        public string Uri { get; set; }
        public string APIKey { get; set; }
        public string SecretKey { get; set; }
    }
}
