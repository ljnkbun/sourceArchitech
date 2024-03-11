using Shopfloor.EventBus.Models.Dtos;

namespace Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories
{
    public class GetPlanningGroupFactoryByIdsResponse
    {
        public GetPlanningGroupFactoryByIdsResponse()
        {
            PlanningGroupFactrories = new();
        }
        public List<PlanningGroupFactoryDto> PlanningGroupFactrories { get; set; }
    }
}
