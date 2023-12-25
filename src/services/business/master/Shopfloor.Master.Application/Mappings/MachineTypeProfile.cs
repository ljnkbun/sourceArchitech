using AutoMapper;
using Shopfloor.Master.Application.Command.MachineTypes;
using Shopfloor.Master.Application.Models.MachineTypes;
using Shopfloor.Master.Application.Parameters.MachineTypes;
using Shopfloor.Master.Application.Query.MachineTypes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.MachineTypes
{
    public class MachineTypeProfile : Profile
    {
        public MachineTypeProfile()
        {
            CreateMap<MachineType, MachineTypeModel>().ReverseMap();
            CreateMap<CreateMachineTypeCommand, MachineType>();
            CreateMap<GetMachineTypesQuery, MachineTypeParameter>();
        }
    }
}
