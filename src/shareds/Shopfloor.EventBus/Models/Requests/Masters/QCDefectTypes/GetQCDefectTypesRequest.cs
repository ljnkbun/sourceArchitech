namespace Shopfloor.EventBus.Models.Requests
{
    public class GetQCDefectTypesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}
