using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Application.Models.ExportArticles;
using Shopfloor.Barcode.Application.Parameters.ExportArticles;
using Shopfloor.Barcode.Application.Query.ExportArticles;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ExportArticleProfile : Profile
    {
        public ExportArticleProfile()
        {
            CreateMap<ExportArticle, ExportArticleModel>()
                .ForMember(x => x.ExportDetailModels, d => d.MapFrom(o => o.ExportDetails))
                .ReverseMap();
            CreateMap<GetExportArticlesQuery, ExportArticleParameter>();
            CreateMap<CreateExportArticleCommand, ExportArticle>();
            CreateMap<UpdateExportArticleCommand, ExportArticle>().ForMember(x => x.ExportDetails, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.EntityState == EntityState.Deleted || source.EntityState == EntityState.Modified))
                .ForMember(dest => dest.ExportId, opt => opt.Condition(source => source.EntityState == EntityState.Added));
        }
    }
}
