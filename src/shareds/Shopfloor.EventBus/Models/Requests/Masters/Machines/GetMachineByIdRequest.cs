namespace Shopfloor.EventBus.Models.Requests.Masters.Machines
{
    public class GetMachineByIdRequest
    {
        public int Id { get; set; }
        public GetMachineByIdRequest(int id)
        {
            Id = id;
        }
    }
}
