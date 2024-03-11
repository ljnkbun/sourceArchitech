namespace Shopfloor.EventBus.Models.Requests
{
    public class GetProfileEfficiencyDetailsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual int ProfileEfficiencyId { get; set; }
        public virtual int SubCategoryId { get; set; }
        public decimal EfficiencyValue { get; set; }
    }
}
