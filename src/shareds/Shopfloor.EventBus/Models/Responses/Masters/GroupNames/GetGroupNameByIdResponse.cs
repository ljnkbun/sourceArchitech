namespace Shopfloor.EventBus.Models.Responses
{
    public class GetGroupNameByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
