using AutoMapper;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxGDIProfile : Profile
    {
        public WfxGDIProfile()
        {
            CreateMap<WfxGDIData, GetWfxGDIDto>().ReverseMap();
            CreateMap<GetWfxGDIQuery, WfxGDIParameter>().ReverseMap();
            CreateMap<WFXAPIGDIMovementData, WFXAPIGDIMovementParams>().ReverseMap();
        }
    }
}
