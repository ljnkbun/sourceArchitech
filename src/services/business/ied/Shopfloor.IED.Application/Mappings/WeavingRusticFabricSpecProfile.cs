using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Models.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Parameters.WeavingRusticFabricSpecs;
using Shopfloor.IED.Application.Query.WeavingRusticFabricSpecs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingRusticFabricSpecs
{
    public class WeavingRusticFabricSpecProfile : Profile
    {
        public WeavingRusticFabricSpecProfile()
        {
            CreateMap<WeavingRusticFabricSpec, WeavingRusticFabricSpecModel>().ReverseMap();
            CreateMap<CreateWeavingRusticFabricSpecCommand, WeavingRusticFabricSpec>();
            CreateMap<UpdateCreateWeavingRusticFabricSpec, WeavingRusticFabricSpec>();
            CreateMap<GetWeavingRusticFabricSpecsQuery, WeavingRusticFabricSpecParameter>();
        }
    }
}
