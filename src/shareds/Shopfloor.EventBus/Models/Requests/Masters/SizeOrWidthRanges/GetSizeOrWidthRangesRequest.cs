namespace Shopfloor.EventBus.Models.Requests
{
    public class GetSizeOrWidthRangesRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string Inseam { get; set; }
    }
}
