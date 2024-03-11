using AutoMapper;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxGDNProfile : Profile
    {
        public WfxGDNProfile()
        {
            CreateMap<WfxGDNData, GetWfxGDNDto>().ReverseMap();
            CreateMap<GetWfxGDNQuery, WfxGDNParameter>().ReverseMap();
            CreateMap<WFXAPIGDNMovementData, WFXAPIGDNMovementParams>().ReverseMap();
        }
    }
}
