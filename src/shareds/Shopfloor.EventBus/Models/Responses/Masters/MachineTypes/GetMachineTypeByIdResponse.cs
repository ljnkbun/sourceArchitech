namespace Shopfloor.EventBus.Models.Responses
{
    public class GetMachineTypeByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
