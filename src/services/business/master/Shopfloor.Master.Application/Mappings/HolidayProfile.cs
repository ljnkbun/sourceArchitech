using AutoMapper;
using Shopfloor.Master.Application.Command.Holidays;
using Shopfloor.Master.Application.Models.Holidays;
using Shopfloor.Master.Application.Parameters.Holidays;
using Shopfloor.Master.Application.Query.Holidays;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Holidays
{
    public class HolidayProfile : Profile
    {
        public HolidayProfile()
        {
            CreateMap<Holiday, HolidayModel>().ReverseMap();
            CreateMap<CreateHolidayCommand, Holiday>();
            CreateMap<GetHolidaysQuery, HolidayParameter>();
        }
    }
}
