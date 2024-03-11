using AutoMapper;
using Shopfloor.Master.Application.Command.Factories;
using Shopfloor.Master.Application.Models.Factories;
using Shopfloor.Master.Application.Parameters.Factories;
using Shopfloor.Master.Application.Query.Factories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class FactoryProfile : Profile
    {
        public FactoryProfile()
        {
            CreateMap<Factory, FactoryModel>()
                .ForMember(dest => dest.DivisionCode, opts => opts.MapFrom(src => src.Divsion.Code))
                .ForMember(dest => dest.DivisionName, opts => opts.MapFrom(src => src.Divsion.Name))
                .ForMember(dest => dest.ProcessIds, opts => opts.MapFrom(src => src.PlanningGroupFactories.Select(x => x.PlanningGroup.ProcessId).Distinct()))
                .ReverseMap();
            CreateMap<CreateFactoryCommand, Factory>();
            CreateMap<GetFactoriesQuery, FactoryParameter>();
        }
    }
}
