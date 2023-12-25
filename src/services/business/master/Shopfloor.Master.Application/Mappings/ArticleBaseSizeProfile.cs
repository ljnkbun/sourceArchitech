using AutoMapper;
using Shopfloor.Master.Application.Models.ArticleBaseSizes;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ArticleBaseSizeProfile : Profile
    {
        public ArticleBaseSizeProfile()
        {
            CreateMap<ArticleBaseSize, ArticleBaseSizeModel>().ReverseMap();
        }
    }
}
