namespace Shopfloor.EventBus.Models.Requests.Masters.Lines
{
    public class GetLineByIdRequest
    {
        public int Id { get; set; }
        public GetLineByIdRequest(int id)
        {
            Id = id;
        }
    }
}
