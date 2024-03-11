namespace Shopfloor.EventBus.Models.Responses.Masters.Lines
{
    public class GetLineByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Worker { get; set; }
        public int? WFXLineId { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
    }
}
