namespace Shopfloor.EventBus.Models.Requests
{
    public class GetProfileEfficienciesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int ProductGroupId { get; set; }
    }
}
