using AutoMapper;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Models.Imports;
using Shopfloor.Barcode.Application.Parameters.Imports;
using Shopfloor.Barcode.Application.Query.Imports;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using System.Collections.Generic;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ImportProfile : Profile
    {
        public ImportProfile()
        {

            CreateMap<Import, ImportModel>()
                .ForMember(x => x.ImportArticleModels, d => d.MapFrom(o => o.ImportArticles))
                .ForMember(x => x.PONo, d => d.MapFrom(o => string.Join(", ", o.ImportArticles.Select(x => x.PONo).Distinct())))
                .ForMember(x => x.ArticleCode, d => d.MapFrom(o => string.Join(", ", o.ImportArticles.Select(x => x.ArticleCode).Distinct())))
                .ForMember(x => x.ArticleName, d => d.MapFrom(o => string.Join(", ", o.ImportArticles.Select(x => x.ArticleName).Distinct())))
                .ForMember(x => x.Supplier, d => d.MapFrom(o => string.Join(", ", o.ImportArticles.Select(x => x.SupplierName).Distinct())))
                .ReverseMap();
            CreateMap<GetImportsQuery, ImportParameter>();
            CreateMap<CreateImportCommand, Import>().ForMember(x => x.Status, opt => opt.MapFrom(src => ImportStatus.Processing));
        }
    }

}
