using AutoMapper;
using Shopfloor.Barcode.Application.Command.Articles;
using Shopfloor.Barcode.Application.Models.Articles;
using Shopfloor.Barcode.Application.Parameters.Articles;
using Shopfloor.Barcode.Application.Query.Articles;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Articles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleModel>().ReverseMap();
            CreateMap<CreateArticleCommand, Article>();
            CreateMap<GetArticlesQuery, ArticleParameter>();
        }
    }
}
