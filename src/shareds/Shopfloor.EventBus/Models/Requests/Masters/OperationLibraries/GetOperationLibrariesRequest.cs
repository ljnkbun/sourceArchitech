namespace Shopfloor.EventBus.Models.Requests
{
    public class GetOperationLibrariesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProcessLibraryId { get; set; }
    }
}
