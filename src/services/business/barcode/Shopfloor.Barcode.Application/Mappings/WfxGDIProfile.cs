using AutoMapper;
using Shopfloor.Barcode.Application.Command.WfxGDIs;
using Shopfloor.Barcode.Application.Models.WfxGDIs;
using Shopfloor.Barcode.Application.Parameters.WfxGDIs;
using Shopfloor.Barcode.Application.Query.WfxGDIs;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.EventBus.Models.Responses;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class WfxGDIProfile : Profile
    {
        public WfxGDIProfile()
        {
            CreateMap<WfxGDI, WfxGDIMasterModel>()
                .ForMember(x => x.Quantity, o => o.MapFrom(p => p.RollUnits))
                .ForMember(x => x.RemainQuantity, o => o.MapFrom(p => p.GDIPendingUnits))
                .ForMember(x => x.Color, o => o.MapFrom(p => p.ColorCode))
                .ForMember(x => x.Size, o => o.MapFrom(p => p.SizeCode))
                .ForMember(x => x.Site, o => o.MapFrom(p => p.WareHouse))
                .ForMember(x => x.Barcode, o => o.MapFrom(p => p.RollBarcode))
                .ForMember(x => x.ParentBarcode, o => o.MapFrom(p => p.ParentRollBarcode))
                .ForMember(x => x.No, o => o.MapFrom(p => p.RollNo))
                .ForMember(x => x.OCRefNum, o => o.MapFrom(p => p.RollOCRefNum))
                .ReverseMap();

            CreateMap<WfxGDI, GetWfxGDIDto>()
                .ForMember(x => x.WFXArticleCode, o => o.MapFrom(p => p.ArticleCode))
                .ForMember(x => x.WFXArticleName, o => o.MapFrom(p => p.ArticleName))
                .ReverseMap();
            CreateMap<GetWfxGDIsQuery, WfxGDIParameter>().ReverseMap();
            CreateMap<WfxGDI, CreateWfxGDICommand>()
                .ForMember(x => x.WFXArticleCode, o => o.MapFrom(p => p.ArticleCode))
                .ForMember(x => x.WFXArticleName, o => o.MapFrom(p => p.ArticleName))
                .ReverseMap();
        }
    }
}
