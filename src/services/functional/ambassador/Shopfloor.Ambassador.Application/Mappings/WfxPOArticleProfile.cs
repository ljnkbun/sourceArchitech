using AutoMapper;
using Shopfloor.Ambassador.Application.Models.Wfxs;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxPOArticleProfile : Profile
    {
        public WfxPOArticleProfile()
        {
            CreateMap<WfxPOArticleData, WfxPOArticleDto>()
                .ReverseMap();
            CreateMap<GetWfxPOArticleQuery, WfxPOArticleParameter>().ReverseMap();
        }
    }
}
