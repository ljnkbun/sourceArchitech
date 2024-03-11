using AutoMapper;
using Shopfloor.Planning.Application.Command.StripFactories;
using Shopfloor.Planning.Application.Models.Articles;
using Shopfloor.Planning.Application.Models.StripFactories;
using Shopfloor.Planning.Application.Parameters.StripFactories;
using Shopfloor.Planning.Application.Query.StripFactories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.StripFactorys
{
    public class StripFactoryProfile : Profile
    {
        public StripFactoryProfile()
        {
            CreateMap<StripFactory, StripFactoryModel>()
                .ForMember(dest => dest.OCNo, opts => opts.MapFrom(src => src.Por.OCNo))
                .ForMember(dest => dest.DeliveryDate, opts => opts.MapFrom(src => src.Por.DeliveryDate))
                .ForMember(dest => dest.PORNo, opts => opts.MapFrom(src => src.Por.PORNo))
                .ForMember(dest => dest.DivisionName, opts => opts.MapFrom(src => src.Por.DivisionName))
                .ForMember(dest => dest.ArticleName, opts => opts.MapFrom(src => src.Por.ArticleName))
                .ForMember(dest => dest.ArticleCode, opts => opts.MapFrom(src => src.Por.ArticleCode))
                .ForMember(dest => dest.Buyer, opts => opts.MapFrom(src => src.Por.Buyer))
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Por.Category))
                .ForMember(dest => dest.SubCategory, opts => opts.MapFrom(src => src.Por.SubCategory))
                .ForMember(dest => dest.ProductGroup, opts => opts.MapFrom(src => src.Por.ProductGroup))
                .ForMember(dest => dest.BOMNo, opts => opts.MapFrom(src => src.Por.BOMNo))
                .ForMember(dest => dest.ProcessName, opts => opts.MapFrom(src => src.Por.ProcessName))
                .ReverseMap();
            CreateMap<CreateStripFactoryCommand, StripFactory>();
            CreateMap<UpdateStripFactoryCommand, StripFactory>();
            CreateMap<GetStripFactoriesQuery, StripFactoryParameter>();
            CreateMap<StripFactory, StripFactoryForFactoryCapacity>();
            CreateMap<StripFactory, StripFactoryPorModel>()
               .ForMember(dest => dest.StripFactoryId, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.OCNo, opts => opts.MapFrom(src => src.Por.OCNo))
               .ForMember(dest => dest.DeliveryDate, opts => opts.MapFrom(src => src.Por.DeliveryDate))
               .ForMember(dest => dest.PORNo, opts => opts.MapFrom(src => src.Por.PORNo))
               .ForMember(dest => dest.DivisionName, opts => opts.MapFrom(src => src.Por.DivisionName))
               .ForMember(dest => dest.ArticleName, opts => opts.MapFrom(src => src.Por.ArticleName))
               .ForMember(dest => dest.ArticleCode, opts => opts.MapFrom(src => src.Por.ArticleCode))
               .ForMember(dest => dest.Buyer, opts => opts.MapFrom(src => src.Por.Buyer))
               .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Por.Category))
               .ForMember(dest => dest.SubCategory, opts => opts.MapFrom(src => src.Por.SubCategory))
               .ForMember(dest => dest.ProductGroup, opts => opts.MapFrom(src => src.Por.ProductGroup))
               .ForMember(dest => dest.BOMNo, opts => opts.MapFrom(src => src.Por.BOMNo))
               .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Por.Quantity))
               .ForMember(dest => dest.RemainingQuantity, opts => opts.MapFrom(src => src.Por.RemainingQuantity))
               .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Por.Type))
               .ForMember(dest => dest.IsAllocated, opts => opts.MapFrom(src => src.Por.IsAllocated))
               .ForMember(dest => dest.ProcessName, opts => opts.MapFrom(src => src.Por.ProcessName))
               .ReverseMap();

            CreateMap<StripFactory, ArticleHistoryModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.OCNo, opts => opts.MapFrom(src => src.Por.OCNo))
                .ForMember(dest => dest.DeliveryDate, opts => opts.MapFrom(src => src.Por.DeliveryDate))
                .ForMember(dest => dest.PORNo, opts => opts.MapFrom(src => src.Por.PORNo))
                .ForMember(dest => dest.DivisionName, opts => opts.MapFrom(src => src.Por.DivisionName))
                .ForMember(dest => dest.ArticleName, opts => opts.MapFrom(src => src.Por.ArticleName))
                .ForMember(dest => dest.ArticleCode, opts => opts.MapFrom(src => src.Por.ArticleCode))
                .ForMember(dest => dest.Buyer, opts => opts.MapFrom(src => src.Por.Buyer))
                .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Por.Category))
                .ForMember(dest => dest.SubCategory, opts => opts.MapFrom(src => src.Por.SubCategory))
                .ForMember(dest => dest.ProductGroup, opts => opts.MapFrom(src => src.Por.ProductGroup))
                .ForMember(dest => dest.BOMNo, opts => opts.MapFrom(src => src.Por.BOMNo))
                .ForMember(dest => dest.ProcessName, opts => opts.MapFrom(src => src.Por.ProcessName))
                .ForMember(dest => dest.Quantity, opts => opts.MapFrom(src => src.Por.Quantity))
                .ForMember(dest => dest.RemainingQuantity, opts => opts.MapFrom(src => src.Por.RemainingQuantity))
                .ReverseMap();
        }
    }
}
