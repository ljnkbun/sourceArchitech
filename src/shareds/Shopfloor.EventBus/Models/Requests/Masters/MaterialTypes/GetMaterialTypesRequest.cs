namespace Shopfloor.EventBus.Models.Requests
{
    public class GetMaterialTypesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
