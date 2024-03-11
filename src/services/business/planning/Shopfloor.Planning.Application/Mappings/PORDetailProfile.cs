using AutoMapper;
using Shopfloor.EventBus.Models.Responses.Ambassadors.Wfxs;
using Shopfloor.Planning.Application.Command.PORDetails;
using Shopfloor.Planning.Application.Models.PORDetails;
using Shopfloor.Planning.Application.Parameters.PORDetails;
using Shopfloor.Planning.Application.Query.PORDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.Mappings
{
    public class PORDetailProfile : Profile
    {
        public PORDetailProfile()
        {
            CreateMap<PORDetail, PORDetailModel>().ReverseMap();
            CreateMap<PORDetail, SplitPorDetailModel>().ReverseMap();
            CreateMap<PORDetail, CreatePORDetailCommand>().ReverseMap();
            CreateMap<GetPORDetailsQuery, PORDetailParameter>();
            CreateMap<PorDetailResponse, PORDetail > ()
               .ForMember(dest => dest.Color, opts => opts.MapFrom(src => src.ColorName))
               .ForMember(dest => dest.Size, opts => opts.MapFrom(src => src.Size))
               .ForMember(dest => dest.OrderedQuantity, opts => opts.MapFrom(src => src.OrderedQty))
               .ForMember(dest => dest.RemainingQuantity, opts => opts.MapFrom(src => src.AllocatedQty));
        }
    }
}
