using AutoMapper;
using Shopfloor.Master.Application.Command.CalendarDetails;
using Shopfloor.Master.Application.Models.CalendarDetails;
using Shopfloor.Master.Application.Parameters.CalendarDetails;
using Shopfloor.Master.Application.Query.CalendarDetails;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.CalendarDetails
{
    public class CalendarDetailProfile : Profile
    {
        public CalendarDetailProfile()
        {
            CreateMap<CalendarDetail, CalendarDetailModel>().ReverseMap();
            CreateMap<CreateCalendarDetailCommand, CalendarDetail>();
            CreateMap<UpdateCalendarDetailCommand, CalendarDetail>();
            CreateMap<GetCalendarDetailsQuery, CalendarDetailParameter>();
        }
    }
}
