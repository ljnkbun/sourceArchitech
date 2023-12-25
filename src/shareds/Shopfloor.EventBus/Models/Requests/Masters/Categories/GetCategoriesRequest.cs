namespace Shopfloor.EventBus.Models.Requests
{
    public class GetCategoriesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
