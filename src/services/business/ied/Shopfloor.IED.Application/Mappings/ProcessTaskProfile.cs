using AutoMapper;
using Shopfloor.IED.Application.Command.ProcessTasks;
using Shopfloor.IED.Application.Models.ProcessTasks;
using Shopfloor.IED.Application.Parameters.ProcessTasks;
using Shopfloor.IED.Application.Query.ProcessTasks;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.ProcessTasks
{
    public class ProcessTaskProfile : Profile
    {
        public ProcessTaskProfile()
        {
            CreateMap<ProcessTask, ProcessTaskModel>().ReverseMap();
            CreateMap<CreateProcessTaskCommand, ProcessTask>();
            CreateMap<GetProcessTasksQuery, ProcessTaskParameter>();
        }
    }
}
