using AutoMapper;
using Shopfloor.Master.Application.Command.Machines;
using Shopfloor.Master.Application.Models.Machines;
using Shopfloor.Master.Application.Parameters.Machines;
using Shopfloor.Master.Application.Query.Machines;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Machines
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<Machine, MachineModel>().ReverseMap();
            CreateMap<CreateMachineCommand, Machine>();
            CreateMap<GetMachinesQuery, MachineParameter>();
        }
    }
}
