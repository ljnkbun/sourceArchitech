namespace Shopfloor.EventBus.Models.Responses
{
    public class GetCategoryByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
