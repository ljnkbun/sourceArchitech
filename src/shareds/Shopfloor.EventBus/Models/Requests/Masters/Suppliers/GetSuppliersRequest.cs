namespace Shopfloor.EventBus.Models.Requests.Masters.Suppliers
{
    public class GetSuppliersRequest : BaseRequest
    {
        public string WFXSupplierId { get; set; }
        public string Name { get; set; }
    }
}
