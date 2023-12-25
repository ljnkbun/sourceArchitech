namespace Shopfloor.EventBus.Models.Responses
{
    public class GetGaugeByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
