namespace Shopfloor.EventBus.Models.Requests.Masters.PlanningGroups
{
    public class GetPlanningGroupFactoriesRequest
    {
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }
    }
}
