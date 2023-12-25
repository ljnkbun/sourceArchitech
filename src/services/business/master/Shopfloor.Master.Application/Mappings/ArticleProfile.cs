using AutoMapper;
using Shopfloor.Master.Application.Models.Articles;
using Shopfloor.Master.Application.Parameters.Articles;
using Shopfloor.Master.Application.Query.Articles;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<GetArticlesQuery, ArticleParameter>();
        }
    }
}
