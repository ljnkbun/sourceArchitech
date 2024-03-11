namespace Shopfloor.EventBus.Models.Responses
{
    public class GetProfileEfficiencyByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int ProductGroupId { get; set; }
    }
}
