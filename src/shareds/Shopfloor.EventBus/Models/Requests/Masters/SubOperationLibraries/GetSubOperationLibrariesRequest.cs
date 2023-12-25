namespace Shopfloor.EventBus.Models.Requests
{
    public class GetSubOperationLibrariesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int OperationLibraryId { get; set; }
    }
}
