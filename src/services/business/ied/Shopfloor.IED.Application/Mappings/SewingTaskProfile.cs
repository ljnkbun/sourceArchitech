using AutoMapper;
using Shopfloor.IED.Application.Command.SewingTasks;
using Shopfloor.IED.Application.Models.SewingTasks;
using Shopfloor.IED.Application.Parameters.SewingTasks;
using Shopfloor.IED.Application.Query.SewingTasks;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingTasks
{
    public class SewingTaskProfile : Profile
    {
        public SewingTaskProfile()
        {
            CreateMap<SewingTask, SewingTaskModel>().ReverseMap();
            CreateMap<CreateSewingTaskCommand, SewingTask>();
            CreateMap<GetSewingTasksQuery, SewingTaskParameter>();
        }
    }
}
