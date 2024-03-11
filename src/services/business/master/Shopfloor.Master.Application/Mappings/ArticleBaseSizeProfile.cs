using AutoMapper;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Application.Models.ArticleBaseSizes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ArticleBaseSizeProfile : Profile
    {
        public ArticleBaseSizeProfile()
        {
            CreateMap<ArticleBaseSize, ArticleBaseSizeModel>().ReverseMap();
            CreateMap<ArticleBaseSize, WfxArticleBaseSizeDto>().ReverseMap();
        }
    }
}
