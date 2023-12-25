namespace Shopfloor.EventBus.Models.Responses
{
    public class GetPaymentTermByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreditDays { get; set; }
    }
}
