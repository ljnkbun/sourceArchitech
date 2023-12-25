using AutoMapper;
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
            CreateMap<ExportArticle, ExportArticleModel>().ReverseMap();
            CreateMap<GetExportArticlesQuery, ExportArticleParameter>();
            CreateMap<CreateExportArticleCommand, ExportArticle>();
            CreateMap<UpdateExportArticleCommand, ExportArticle>();
        }
    }
}
