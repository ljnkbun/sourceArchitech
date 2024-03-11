namespace Shopfloor.EventBus.Models.Responses.Masters.PlanningGroupFactories
{
    public class GetPlanningGroupFactoriesResponse : BaseResponse
    {
        public List<GetPlanningGroupFactoryByIdResponse> Data { get; set; }
    }

}
