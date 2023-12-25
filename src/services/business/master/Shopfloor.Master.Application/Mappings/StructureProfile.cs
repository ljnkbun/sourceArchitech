using AutoMapper;
using Shopfloor.Master.Application.Command.Structures;
using Shopfloor.Master.Application.Models.Structures;
using Shopfloor.Master.Application.Parameters.Structures;
using Shopfloor.Master.Application.Query.Structures;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Structures
{
    public class StructureProfile : Profile
    {
        public StructureProfile()
        {
            CreateMap<Structure, StructureModel>().ReverseMap();
            CreateMap<CreateStructureCommand, Structure>();
            CreateMap<GetStructuresQuery, StructureParameter>();
        }
    }
}
