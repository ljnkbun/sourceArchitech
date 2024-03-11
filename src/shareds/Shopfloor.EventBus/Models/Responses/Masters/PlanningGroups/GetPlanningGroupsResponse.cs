namespace Shopfloor.EventBus.Models.Responses.Masters.PlanningGroups
{
    public class GetPlanningGroupsResponse : BaseResponse
    {
        public List<GetPlanningGroupByIdResponse> Data { get; set; }
    }

}
