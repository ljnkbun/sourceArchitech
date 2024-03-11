namespace Shopfloor.EventBus.Models.Requests.Masters.Calendars
{
    public class GetCalendarsRequest : BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
