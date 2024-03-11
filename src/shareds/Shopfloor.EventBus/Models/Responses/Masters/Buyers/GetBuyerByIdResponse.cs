namespace Shopfloor.EventBus.Models.Responses.Masters.Buyers
{
    public class GetBuyerByIdResponse : BaseResponse
    {
        public string WFXBuyerId { get; set; }
        public string Name { get; set; }
    }
}
