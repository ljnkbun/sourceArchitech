namespace Shopfloor.EventBus.Models.Responses
{
    public class GetArticlesByIdsResponse : BaseResponse
    {
        public List<GetArticleByIdResponse> Data { get; set; }
    }
}
