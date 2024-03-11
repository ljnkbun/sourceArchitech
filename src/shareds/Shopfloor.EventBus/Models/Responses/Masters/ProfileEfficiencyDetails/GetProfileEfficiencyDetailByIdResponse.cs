namespace Shopfloor.EventBus.Models.Responses
{
    public class GetProfileEfficiencyDetailByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProfileEfficiencyId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal EfficiencyValue { get; set; }
    }
}
