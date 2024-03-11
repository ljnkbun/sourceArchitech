using AutoMapper;
using Shopfloor.Barcode.Application.Models.WfxPOArticles;
using Shopfloor.Barcode.Application.Parameters.WfxPOArticles;
using Shopfloor.Barcode.Application.Query.WfxPOArticles;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.EventBus.Models.Responses;
using System.Globalization;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class WfxPOArticleProfile : Profile
    {
        public WfxPOArticleProfile()
        {
            CreateMap<WfxPOArticle, WfxPOArticleMasterModel>()
                .ForMember(x => x.Units, o => o.MapFrom(p => p.Quantity))
                .ForMember(x => x.OrderCreationDate, o => o.MapFrom(p => p.POCreationDate))
                .ForMember(x => x.OCNum, o => o.MapFrom(p => p.OCFactory))
                .ForMember(x => x.SupplierName, o => o.MapFrom(p => p.Supplier))
                .ForMember(x => x.SupplierShortName, o => o.MapFrom(p => p.Supplier))
                .ReverseMap();
            CreateMap<WfxPOArticle, WfxPOArticleParentModel>()
                .ForMember(x => x.Units, o => o.MapFrom(p => p.Quantity))
                .ForMember(x => x.OrderCreationDate, o => o.MapFrom(p => p.POCreationDate))
                .ForMember(x => x.OCNum, o => o.MapFrom(p => p.OCFactory))
                .ForMember(x => x.SupplierName, o => o.MapFrom(p => p.Supplier))
                .ForMember(x => x.SupplierShortName, o => o.MapFrom(p => p.Supplier))
                .ReverseMap();
            CreateMap<WfxPOArticle, WfxPOArticleChildModel>()
                .ForMember(x => x.Units, o => o.MapFrom(p => p.Quantity))
                .ForMember(x => x.OrderCreationDate, o => o.MapFrom(p => p.POCreationDate))
                .ForMember(x => x.OCNum, o => o.MapFrom(p => p.OCFactory))
                .ForMember(x => x.SupplierName, o => o.MapFrom(p => p.Supplier))
                .ForMember(x => x.SupplierShortName, o => o.MapFrom(p => p.Supplier))
                .ReverseMap();
            CreateMap<WfxPOArticleMasterModel, WfxPOArticleParentModel>().ReverseMap();
            CreateMap<WfxPOArticleMasterModel, WfxPOArticleChildModel>().ReverseMap();
            CreateMap<WfxPOArticleParentModel, WfxPOArticleChildModel>().ReverseMap();
            CreateMap<WfxPOArticleDto, WfxPOArticle>()
               .ForMember(x => x.PONo, o => o.MapFrom(p => p.RMPONO))
               .ForMember(x => x.SizeCode, o => o.MapFrom(p => p.SizeCodes))
               .ForMember(x => x.SizeName, o => o.MapFrom(p => p.SizeName))
               .ForMember(x => x.ColorCode, o => o.MapFrom(p => p.ColorCodes))
               .ForMember(x => x.ColorName, o => o.MapFrom(p => p.ColorDesc))
               .ForMember(x => x.Quantity, o => o.MapFrom(p => decimal.Parse(p.TotalUnits ?? "0")))
               .ForMember(x => x.POCreationDate, o => o.MapFrom(p => p.POCreationDate == string.Empty ? (DateTime?)null : DateTime.Parse(p.POCreationDate, new CultureInfo("en-US"))))
               .ForMember(x => x.PPYDGDate, o => o.MapFrom(p => p.PPYDGDate == string.Empty ? (DateTime?)null : DateTime.Parse(p.PPYDGDate, new CultureInfo("en-US"))))
               .ForMember(x => x.LastRevisedDate, o => o.MapFrom(p => p.LastRevisedDate == string.Empty ? (DateTime?)null : DateTime.Parse(p.LastRevisedDate, new CultureInfo("en-US"))))
               .ForMember(x => x.InHouseDate, o => o.MapFrom(p => p.InHouseDate == string.Empty ? (DateTime?)null : DateTime.Parse(p.InHouseDate, new CultureInfo("en-US"))))
               .ReverseMap();
            CreateMap<GetWfxPOArticlesQuery, WfxPOArticleParameter>();
        }
    }
}
