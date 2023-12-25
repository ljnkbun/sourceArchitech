namespace Shopfloor.EventBus.Models.Requests
{
    public class GetUOMConversionsRequest : BaseRequest
    {
        public int? FromUOMId { get; set; }
        public int? ToUOMId { get; set; }
        public decimal? Value { get; set; }
    }
}
