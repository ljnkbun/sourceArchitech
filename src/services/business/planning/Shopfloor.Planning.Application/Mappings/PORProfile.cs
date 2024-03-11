using AutoMapper;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;
using Shopfloor.Planning.Application.Command.PORs;
using Shopfloor.Planning.Application.Models.PORDetails;
using Shopfloor.Planning.Application.Models.PORs;
using Shopfloor.Planning.Application.Parameters.PORs;
using Shopfloor.Planning.Application.Query.PORs;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Enums;

namespace Shopfloor.Planning.Application.Mappings
{
    public class PORProfile : Profile
    {
        public PORProfile()
        {
            CreateMap<POR, PORModel>()
                .ForMember(dest => dest.FromPor, opts => opts.MapFrom(src => string.Join(',', src.ToMergeSplitPORs.Select(x => x.FromPOR.PORNo))))
                .ForMember(dest => dest.ToPor, opts => opts.MapFrom(src => string.Join(',', src.FromMergeSplitPORs.Select(x => x.ToPOR.PORNo))))
                .ReverseMap();
            CreateMap<POR, CreatePORCommand>().ReverseMap();
            CreateMap<GetPORsQuery, PORParameter>();
            CreateMap<GetWfxPorResponse, POR>()
                 .ForMember(dest => dest.OCNo, opts => opts.MapFrom(src => src.OCSRServiceNo))
                .ForMember(dest => dest.WfxPORId, opts => opts.MapFrom(src => src.ProductionOrderID))
                .ForMember(dest => dest.PORNo, opts => opts.MapFrom(src => src.ProductionOrderNo))
                .ForMember(dest => dest.WfxArticleId, opts => opts.MapFrom(src => src.ArticleID))
                .ForMember(dest => dest.ArticleName, opts => opts.MapFrom(src => src.ArticleName))
                .ForMember(dest => dest.ArticleCode, opts => opts.MapFrom(src => src.ArticleCode))
                .ForMember(dest => dest.Buyer, opts => opts.MapFrom(src => src.Buyer))
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category))
                .ForMember(dest => dest.ProductGroup, opts => opts.MapFrom(src => src.ProductGroup))
                .ForMember(dest => dest.BOMId, opts => opts.MapFrom(src => src.BOMID))
                .ForMember(dest => dest.BOMNo, opts => opts.MapFrom(src => src.BOMNo))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.TotalQty))
                .ForMember(dest => dest.RemainingQuantity, opts => opts.MapFrom(src => src.TotalQty))
                .ForMember(dest => dest.ProcessId, opts => opts.MapFrom(src => src.ProcessID))
                .ForMember(dest => dest.ProcessName, opts => opts.MapFrom(src => src.Process))
                .ForMember(dest => dest.OrderId, opts => opts.MapFrom(src => src.OrderID))
                .ForMember(dest => dest.PORDetails, opts => opts.MapFrom(src => src.ColorSizeDetails))
                .ForMember(dest => dest.UOM, opts => opts.MapFrom(src => src.UOM))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status))
                .ForMember(dest => dest.OCStatus, opts => opts.MapFrom(src => src.OCStatus));
        }
    }
}
