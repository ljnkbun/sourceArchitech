using AutoMapper;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Application.Parameters.WfxPOArticles;
using Shopfloor.Barcode.Application.Query.WfxPOArticles;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class WfxPOArticleProfile : Profile
    {
        public WfxPOArticleProfile()
        {
            CreateMap<WfxPOArticle, WfxPOArticleModel>().ReverseMap();
            CreateMap<WfxPOArticle, WfxPOArticleDto>().ReverseMap();
            CreateMap<GetWfxPOArticlesQuery, WfxPOArticleParameter>();
        }
    }
}
