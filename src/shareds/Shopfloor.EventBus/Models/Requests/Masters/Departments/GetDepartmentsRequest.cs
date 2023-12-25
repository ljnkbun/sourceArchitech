namespace Shopfloor.EventBus.Models.Requests
{
    public class GetDepartmentsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }
    }
}
