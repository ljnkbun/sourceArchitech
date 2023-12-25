using AutoMapper;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxMasterDataProfile : Profile
    {
        public WfxMasterDataProfile()
        {
            CreateMap<WfxMasterData, WfxMasterDataDto>().ReverseMap();
            CreateMap<GetWfxMasterDataQuery, WfxMasterDataParameter>().ReverseMap();
        }
    }
}
