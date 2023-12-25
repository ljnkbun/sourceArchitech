using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingArticles;
using Shopfloor.IED.Application.Models.WeavingArticles;
using Shopfloor.IED.Application.Parameters.WeavingArticles;
using Shopfloor.IED.Application.Query.WeavingArticles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingArticles
{
    public class WeavingArticleProfile : Profile
    {
        public WeavingArticleProfile()
        {
            CreateMap<WeavingArticle, WeavingArticleModel>().ReverseMap();
            CreateMap<CreateWeavingArticleCommand, WeavingArticle>();
            CreateMap<GetWeavingArticlesQuery, WeavingArticleParameter>();
        }
    }
}
