namespace Shopfloor.EventBus.Models.Requests.Masters.Factories
{
    public class GetFactoryByIdRequest
    {
        public int Id { get; set; }
        public GetFactoryByIdRequest(int id)
        {
            Id = id;
        }
    }
}
