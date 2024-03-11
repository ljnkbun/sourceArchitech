using AutoMapper;
using Shopfloor.Master.Application.Command.Processes;
using Shopfloor.Master.Application.Models.Processes;
using Shopfloor.Master.Application.Parameters.Processes;
using Shopfloor.Master.Application.Query.Processes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ProcessProfile : Profile
    {
        public ProcessProfile()
        {
            CreateMap<Process, ProcessModel>().ReverseMap();
            CreateMap<CreateProcessCommand, Process>();
            CreateMap<GetProcessesQuery, ProcessParameter>();
            CreateMap<GetProcessesByDivisionCodeQuery, ProcessByDivisionIdParameter>();
        }
    }
}