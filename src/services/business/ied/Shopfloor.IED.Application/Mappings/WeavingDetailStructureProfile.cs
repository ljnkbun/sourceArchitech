using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingDetailStructures;
using Shopfloor.IED.Application.Models.WeavingDetailStructures;
using Shopfloor.IED.Application.Parameters.WeavingDetailStructures;
using Shopfloor.IED.Application.Query.WeavingDetailStructures;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingDetailStructures
{
    public class WeavingDetailStructureProfile : Profile
    {
        public WeavingDetailStructureProfile()
        {
            CreateMap<WeavingDetailStructure, WeavingDetailStructureModel>().ReverseMap();
            CreateMap<CreateWeavingDetailStructureCommand, WeavingDetailStructure>();
            CreateMap<UpdateCreateWeavingDetailStructure, WeavingDetailStructure>();
            CreateMap<GetWeavingDetailStructuresQuery, WeavingDetailStructureParameter>();
        }
    }
}
