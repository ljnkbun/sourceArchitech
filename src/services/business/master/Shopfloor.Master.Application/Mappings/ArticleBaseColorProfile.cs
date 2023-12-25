using AutoMapper;
using Shopfloor.Master.Application.Models.ArticleBaseColors;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ArticleBaseColorProfile : Profile
    {
        public ArticleBaseColorProfile()
        {
            CreateMap<ArticleBaseColor, ArticleBaseColorModel>().ReverseMap();
        }
    }
}
