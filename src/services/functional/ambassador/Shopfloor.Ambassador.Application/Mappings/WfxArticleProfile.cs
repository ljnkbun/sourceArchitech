using AutoMapper;
using Shopfloor.Ambassador.Application.Models;
using Shopfloor.Ambassador.Application.Parameters;
using Shopfloor.Ambassador.Application.Query;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Ambassador.Application.Mappings
{
    public class WfxArticleProfile : Profile
    {
        public WfxArticleProfile()
        {
            CreateMap<WfxArticle, WfxArticleDto>().ReverseMap();
            CreateMap<WfxArticleBaseColor, WfxArticleBaseColorDto>().ReverseMap();
            CreateMap<WfxArticleFlexField, WfxArticleFlexFieldDto>().ReverseMap();
            CreateMap<WfxArticleBaseSize, WfxArticleBaseSizeDto>().ReverseMap();
            CreateMap<GetWfxArticleQuery, WfxArticleParameter>().ReverseMap();
        }
    }
}
