namespace Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups
{
    public class GetPlanningGroupByIdResponse
    {
        public GetPlanningGroupByIdResponse()
        {
            PlanningGroupFactories = new List<PlanningGroupFactory>();
        }

        public int Id { get; set; }
        public int ProcessId { get; set; }
        public int CalendarId { get; set; }

        public List<PlanningGroupFactory> PlanningGroupFactories { get; set; }
    }

    public class PlanningGroupFactory
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
    }
}
