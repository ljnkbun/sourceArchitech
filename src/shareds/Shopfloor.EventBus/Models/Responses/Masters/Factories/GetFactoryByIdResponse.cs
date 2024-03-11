namespace Shopfloor.EventBus.Models.Responses.Masters.Factories
{
    public class GetFactoryByIdResponse: BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int? DivisionId { get; set; }
        public string DivisionName { get; set; }
        public string DivisionCode { get; set; }
        public List<int> ProcessIds { get; set; }
    }
}
