namespace Shopfloor.EventBus.Models.Responses
{
    public class GetUOMConversionByIdResponse : BaseResponse
    {

        public int? FromUOMId { get; set; }
        public int? ToUOMId { get; set; }
        public decimal? Value { get; set; }
    }
}
