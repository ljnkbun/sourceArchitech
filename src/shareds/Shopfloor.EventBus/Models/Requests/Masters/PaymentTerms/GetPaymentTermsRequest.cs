namespace Shopfloor.EventBus.Models.Requests
{
    public class GetPaymentTermsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditDays { get; set; }
    }
}
