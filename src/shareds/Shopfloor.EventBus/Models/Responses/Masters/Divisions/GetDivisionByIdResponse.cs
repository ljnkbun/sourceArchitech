namespace Shopfloor.EventBus.Models.Responses.Divisions
{
    public class GetDivisionByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}