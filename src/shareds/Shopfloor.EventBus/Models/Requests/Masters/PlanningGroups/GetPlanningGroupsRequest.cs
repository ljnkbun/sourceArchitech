namespace Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups
{
    public class GetPlanningGroupsRequest
    {
        public int? ProcessId { get; set; }
        public int? CalendarId { get; set; }
    }
}
