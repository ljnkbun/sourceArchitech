using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingOperationInputArticles;
using Shopfloor.IED.Application.Models.WeavingOperationInputArticles;
using Shopfloor.IED.Application.Parameters.WeavingOperationInputArticles;
using Shopfloor.IED.Application.Query.WeavingOperationInputArticles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class WeavingOperationInputArticleProfile : Profile
    {
        public WeavingOperationInputArticleProfile()
        {
            CreateMap<WeavingOperationInputArticle, WeavingOperationInputArticleModel>().ReverseMap();
            CreateMap<CreateWeavingOperationInputArticleCommand, WeavingOperationInputArticle>();
            CreateMap<UpdateWeavingOperationInputArticleCommand, WeavingOperationInputArticle>();
            CreateMap<GetWeavingOperationInputArticlesQuery, WeavingOperationInputArticleParameter>();
        }
    }
}