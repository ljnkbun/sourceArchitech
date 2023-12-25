namespace Shopfloor.EventBus.Models.Responses
{
    public class GetOperationLibraryByIdResponse : BaseResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessLibraryId { get; set; }
    }
}
