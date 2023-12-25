namespace Shopfloor.EventBus.Models.Requests
{
    public class GetYarnCompositionsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
