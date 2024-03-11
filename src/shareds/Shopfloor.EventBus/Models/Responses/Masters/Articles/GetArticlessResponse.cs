namespace Shopfloor.EventBus.Models.Responses
{
    public class GetArticlessResponse : BaseResponse
    {
        public List<GetArticleByIdResponse> Data { get; set; }
    }
}
