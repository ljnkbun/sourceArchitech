using AutoMapper;
using Shopfloor.Master.Application.Command.Constructions;
using Shopfloor.Master.Application.Models.Constructions;
using Shopfloor.Master.Application.Parameters.Constructions;
using Shopfloor.Master.Application.Query.Constructions;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Constructions
{
    public class ConstructionProfile : Profile
    {
        public ConstructionProfile()
        {
            CreateMap<Construction, ConstructionModel>().ReverseMap();
            CreateMap<CreateConstructionCommand, Construction>();
            CreateMap<GetConstructionsQuery, ConstructionParameter>();
        }
    }
}
