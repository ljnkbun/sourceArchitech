namespace Shopfloor.EventBus.Models.Responses
{
    public class GetColorDefinitionByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
