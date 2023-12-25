using AutoMapper;
using Shopfloor.Master.Application.Command.SpinningProcesses;
using Shopfloor.Master.Application.Models.SpinningProcesses;
using Shopfloor.Master.Application.Parameters.SpinningProcesses;
using Shopfloor.Master.Application.Query.SpinningProcesses;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.SpinningProcesses
{
    public class SpinningProcessProfile : Profile
    {
        public SpinningProcessProfile()
        {
            CreateMap<SpinningProcess, SpinningProcessModel>().ReverseMap();
            CreateMap<CreateSpinningProcessCommand, SpinningProcess>();
            CreateMap<GetSpinningProcessesQuery, SpinningProcessParameter>();
        }
    }
}
