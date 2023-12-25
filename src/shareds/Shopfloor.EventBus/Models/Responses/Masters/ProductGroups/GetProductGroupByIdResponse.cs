namespace Shopfloor.EventBus.Models.Responses
{
    public class GetProductGroupByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
