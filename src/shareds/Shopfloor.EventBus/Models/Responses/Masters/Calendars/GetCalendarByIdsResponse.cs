namespace Shopfloor.EventBus.Models.Responses
{
    public class GetCalendarByIdsResponse
    {
        public GetCalendarByIdsResponse()
        {
            Calendars = new();
        }
        public List<GetCalendarByIdResponse> Calendars { get; set; }
    }
}
