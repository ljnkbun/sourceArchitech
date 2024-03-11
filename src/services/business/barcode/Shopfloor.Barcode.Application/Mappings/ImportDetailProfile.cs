using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Application.Models.ImportDetails;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Application.Parameters.ImportDetails;
using Shopfloor.Barcode.Application.Query.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class ImportDetailProfile : Profile
    {
        public ImportDetailProfile()
        {
            CreateMap<ImportDetail, PrintImportDetailModel>()
                .ForMember(x => x.FromSite, opt => opt.MapFrom(src => src.ImportArticle.FromSite))
                .ForMember(x => x.ToSite, opt => opt.MapFrom(src => src.ImportArticle.ToSite))
                .ForMember(x => x.GDNNumber, opt => opt.MapFrom(src => src.ImportArticle.GDNNumber))
                .ForMember(x => x.SupplierName, opt => opt.MapFrom(src => src.ImportArticle.SupplierName))
                .ForMember(x => x.OrderRefNum, opt => opt.MapFrom(src => src.ImportArticle.OrderRefNum))
                .ForMember(x => x.Unit, opt => opt.MapFrom(src => src.UOM))
                .ForMember(x => x.ArticleBarcode, opt => opt.MapFrom(src => src.ArticleBarcode.Barcode));
            CreateMap<ImportDetail, ImportDetailModel>()
                .ForMember(x => x.ArticleBarcodeModel, d => d.MapFrom(o => o.ArticleBarcode))
                .ReverseMap();
            CreateMap<ImportDetailModel, WfxPOArticleChildModel>().ReverseMap();
            CreateMap<GetImportDetailsQuery, ImportDetailParameter>();
            CreateMap<CreateImportDetailCommand, ImportDetail>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => ItemStatus.BEFORE_CHECKIN));
            CreateMap<UpdateImportDetailCommand, ImportDetail>().ForMember(x => x.AriticleBarcodeId, opt => opt.Condition(source => source.EntityState == EntityState.Added && source.Type == ImportType.ImportTransferToSite))
                                                                .ForMember(dest => dest.ImportArticleId, opt => opt.Condition(source => source.EntityState == EntityState.Added))
                                                                .ForMember(dest => dest.Id, opt => opt.Condition(source => source.EntityState == EntityState.Deleted || source.EntityState == EntityState.Modified))
                                                                .ForPath(x => x.ArticleBarcode.CurrentLocationId, opt => opt.MapFrom(src => src.LocationId));
        }
    }

}
