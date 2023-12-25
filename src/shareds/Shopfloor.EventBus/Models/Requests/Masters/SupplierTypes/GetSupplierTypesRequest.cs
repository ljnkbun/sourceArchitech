namespace Shopfloor.EventBus.Models.Requests
{
    public class GetSupplierTypesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
