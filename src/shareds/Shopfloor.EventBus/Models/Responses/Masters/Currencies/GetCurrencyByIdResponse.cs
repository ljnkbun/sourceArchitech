namespace Shopfloor.EventBus.Models.Responses
{
    public class GetCurrencyByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
