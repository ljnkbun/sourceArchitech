using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportArticles;
using Shopfloor.Barcode.Application.Models.ImportArticles;
using Shopfloor.Barcode.Application.Parameters.ImportArticles;
using Shopfloor.Barcode.Application.Query.ImportArticles;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ImportArticleProfile : Profile
    {
        public ImportArticleProfile()
        {
            CreateMap<ImportArticle, ImportArticleModel>().ReverseMap();
            CreateMap<CreateImportArticleCommand, ImportArticle>();
            CreateMap<GetImportArticlesQuery, ImportArticleParameter>();
            CreateMap<UpdateImportArticleCommand, ImportArticle>()
                .ForMember(x => x.ImportDetails, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.EntityState == EntityState.Deleted || source.EntityState == EntityState.Modified))
                .ForMember(dest => dest.ImportId, opt => opt.Condition(source => source.EntityState == EntityState.Added));
        }
    }
   
}
