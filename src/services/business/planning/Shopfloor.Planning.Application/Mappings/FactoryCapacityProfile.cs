using AutoMapper;
using Shopfloor.Planning.Application.Helpers;
using Shopfloor.Planning.Application.Models.FactoryCapacitys;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.FactoryCapacitys
{
    public class FactoryCapacityProfile : Profile
    {
        public FactoryCapacityProfile()
        {
            CreateMap<FactoryCapacity, FactoryCapacityModel>().ReverseMap();
            CreateMap<FactoryCapacity, FactoryCapacityModel>()
                        .ForMember(dest => dest.Week, opt => opt.MapFrom(src => DateHelper.GetWeekNumber(src.Date)))
                        .ForMember(dest => dest.Month, opt => opt.MapFrom(src => DateHelper.GetMonthNumber(src.Date)));
        }
    }
}
