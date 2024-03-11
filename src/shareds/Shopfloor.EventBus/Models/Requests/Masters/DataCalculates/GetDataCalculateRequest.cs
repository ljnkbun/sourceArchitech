namespace Shopfloor.EventBus.Models.Requests
{
    public class GetDataCalculateRequest : BaseRequest
    {
        public int PlanningGroupId { get; set; }
        public int? MachineId { get; set; }
        public int? LineId { get; set; }
    }
}
