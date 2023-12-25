namespace Shopfloor.EventBus.Models.Requests
{
    public class BaseRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool BypassCache { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
    }
}
