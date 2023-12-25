namespace Shopfloor.EventBus.Models.Responses
{
    public class GetDepartmentByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
    }
}
