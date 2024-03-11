using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ExportDetails;
using Shopfloor.Barcode.Application.Models.ExportDetails;
using Shopfloor.Barcode.Application.Parameters.ExportDetails;
using Shopfloor.Barcode.Application.Query.ExportDetails;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ExportDetailProfile : Profile
    {
        public ExportDetailProfile()
        {
            CreateMap<ExportDetail, ExportDetailModel>()
                .ForMember(x => x.ArticleBarcodeModel, d => d.MapFrom(o => o.ArticleBarcode))
                .ReverseMap();
            CreateMap<ExportDetail, ExportDetailExcelModel>().ReverseMap();
            CreateMap<GetExportDetailsQuery, ExportDetailParameter>();
            CreateMap<CreateExportDetailCommand, ExportDetail>();
            CreateMap<UpdateExportDetailCommand, ExportDetail>()
                                                                .ForMember(dest => dest.ExportArticleId, opt => opt.Condition(source => source.EntityState == EntityState.Added))
                                                                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.EntityState == EntityState.Deleted || source.EntityState == EntityState.Modified))
                                                                .ForPath(x => x.ArticleBarcode.CurrentLocationId, opt => opt.MapFrom(src => src.LocationId));
        }
    }
}
