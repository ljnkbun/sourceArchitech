using AutoMapper;
using Shopfloor.Master.Application.Command.PlanningGroupFactories;
using Shopfloor.Master.Application.Models.PlanningGroupFactories;
using Shopfloor.Master.Application.Parameters.PlanningGroupFactories;
using Shopfloor.Master.Application.Query.PlanningGroupFactories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.PlanningGroupFactorys
{
    public class PlanningGroupFactoryProfile : Profile
    {
        public PlanningGroupFactoryProfile()
        {
            CreateMap<PlanningGroupFactory, PlanningGroupFactoryModel>().ReverseMap();
            CreateMap<CreatePlanningGroupFactoryCommand, PlanningGroupFactory>();
            CreateMap<UpdatePlanningGroupFactoryCommand, PlanningGroupFactory>();
            CreateMap<GetPlanningGroupFactoriesQuery, PlanningGroupFactoryParameter>();
        }
    }
}
