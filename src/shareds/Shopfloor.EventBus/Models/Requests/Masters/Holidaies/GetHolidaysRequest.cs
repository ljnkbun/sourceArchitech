namespace Shopfloor.EventBus.Models.Requests
{
    public class GetHolidaysRequest : BaseRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
		public string Description { get; set; }
    }
}
