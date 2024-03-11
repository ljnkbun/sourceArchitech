using AutoMapper;
using Shopfloor.Master.Application.Command.PlanningGroups;
using Shopfloor.Master.Application.Models.PlanningGroups;
using Shopfloor.Master.Application.Parameters.PlanningGroups;
using Shopfloor.Master.Application.Query.PlanningGroups;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.PlanningGroups
{
    public class PlanningGroupProfile : Profile
    {
        public PlanningGroupProfile()
        {
            CreateMap<PlanningGroup, PlanningGroupModel>().ReverseMap();
            CreateMap<CreatePlanningGroupCommand, PlanningGroup>();
            CreateMap<UpdatePlanningGroupCommand, PlanningGroup>();
            CreateMap<GetPlanningGroupsQuery, PlanningGroupParameter>();
        }
    }
}
