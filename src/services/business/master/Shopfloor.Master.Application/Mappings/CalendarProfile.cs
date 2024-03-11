using AutoMapper;
using Shopfloor.Master.Application.Command.Calendars;
using Shopfloor.Master.Application.Models.Calendars;
using Shopfloor.Master.Application.Parameters.Calendars;
using Shopfloor.Master.Application.Query.Calendars;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Calendars
{
    public class CalendarProfile : Profile
    {
        public CalendarProfile()
        {
            CreateMap<Calendar, CalendarModel>().ReverseMap();
            CreateMap<CreateCalendarCommand, Calendar>();
            CreateMap<GetCalendarsQuery, CalendarParameter>();
        }
    }
}
