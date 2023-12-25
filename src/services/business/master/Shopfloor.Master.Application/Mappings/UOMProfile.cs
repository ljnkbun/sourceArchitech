using AutoMapper;
using Shopfloor.Master.Application.Command.UOMs;
using Shopfloor.Master.Application.Models.UOMs;
using Shopfloor.Master.Application.Parameters.UOMs;
using Shopfloor.Master.Application.Query.UOMs;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class UOMProfile : Profile
    {
        public UOMProfile()
        {
            CreateMap<UOM, UOMModel>().ReverseMap();
            CreateMap<CreateUOMCommand, UOM>();
            CreateMap<GetUOMsQuery, UOMParameter>();
        }
    }
}
