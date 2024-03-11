using AutoMapper;
using Shopfloor.Ambassador.Application.Parameters.Wpfs;
using Shopfloor.Ambassador.Application.Query.Wfxs;
using Shopfloor.EventBus.Models.Dtos;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxPorSyncProfile : Profile
    {
        public WfxPorSyncProfile() { 
            CreateMap<GetWfxPorResponse, PorDto>().ReverseMap();
            CreateMap<GetWfxPorDataQuery, WfxPorParameter>().ReverseMap();
        }
    }
}
