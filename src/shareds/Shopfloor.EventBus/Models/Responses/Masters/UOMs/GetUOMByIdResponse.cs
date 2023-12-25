namespace Shopfloor.EventBus.Models.Responses
{
    public class GetUOMByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
