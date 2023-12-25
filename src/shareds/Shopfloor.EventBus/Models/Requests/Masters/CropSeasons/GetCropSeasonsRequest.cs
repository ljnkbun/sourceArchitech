namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCropSeasonsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
