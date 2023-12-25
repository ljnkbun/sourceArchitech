namespace Shopfloor.EventBus.Models.Responses
{
    public class GetBuyerTypeByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
