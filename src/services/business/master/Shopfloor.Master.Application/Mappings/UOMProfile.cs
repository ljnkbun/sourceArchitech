using AutoMapper;
using Shopfloor.Master.Application.Command.UOMs;
using Shopfloor.Master.Application.Models.ProductGroups;
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
            CreateMap<UOM, UOMModel>().ForMember(dest => dest.ProductGroup, opt => opt.MapFrom(src =>
                src.ProductGroupUOMs.Select(x => x.ProductGroup)));
            CreateMap<UOMModel, UOM>();
            CreateMap<CreateUOMCommand, UOM>();
            CreateMap<GetUOMsQuery, UOMParameter>();
        }
    }
}
