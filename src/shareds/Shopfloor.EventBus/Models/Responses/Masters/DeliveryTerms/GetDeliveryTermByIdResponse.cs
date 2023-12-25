namespace Shopfloor.EventBus.Models.Responses
{
    public class GetDeliveryTermByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
