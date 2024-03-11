namespace Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories
{
    public class GetPlanningGroupFactoryByIdResponse
    {
        public int Id { get; set; }
        public int PlanningGroupId { get; set; }
        public int FactoryId { get; set; }
        public string FactoryName { get; set; }
        public string ProcessName { get; set; }
    }
}
