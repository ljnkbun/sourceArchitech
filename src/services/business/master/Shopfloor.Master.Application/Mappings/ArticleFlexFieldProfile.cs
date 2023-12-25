using AutoMapper;
using Shopfloor.Master.Application.Models.ArticleFlexFields;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ArticleFlexFieldProfile : Profile
    {
        public ArticleFlexFieldProfile()
        {
            CreateMap<ArticleFlexField, ArticleFlexFieldModel>().ReverseMap();
        }
    }
}
