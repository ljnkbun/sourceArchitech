namespace Shopfloor.EventBus.Models.Responses.Masters.Suppliers
{
    public class GetSupplierByIdResponse : BaseResponse
    {
        public string WFXSupplierId { get; set; }
        public string Name { get; set; }
    }
}
