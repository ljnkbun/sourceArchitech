using AutoMapper;
using Shopfloor.Planning.Application.Helpers;
using Shopfloor.Planning.Application.Models.LineMachineCapacities;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.LineMachineCapacitys
{
    public class LineMachineCapacityProfile : Profile
    {
        public LineMachineCapacityProfile()
        {
            CreateMap<LineMachineCapacity, LineMachineCapacityModel>().ReverseMap();
            CreateMap<LineMachineCapacity, LineMachineCapacityModel>()
                        .ForMember(dest => dest.Week, opt => opt.MapFrom(src => DateHelper.GetWeekNumber(src.Date)))
                        .ForMember(dest => dest.Month, opt => opt.MapFrom(src => DateHelper.GetMonthNumber(src.Date)));
        }
    }
}
