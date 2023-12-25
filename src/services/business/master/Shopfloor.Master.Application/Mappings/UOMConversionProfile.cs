using AutoMapper;
using Shopfloor.Master.Application.Command.UOMConversions;
using Shopfloor.Master.Application.Models.UOMConversions;
using Shopfloor.Master.Application.Parameters.UOMConversions;
using Shopfloor.Master.Application.Query.UOMConversions;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.UOMConversions
{
    public class UOMConversionProfile : Profile
    {
        public UOMConversionProfile()
        {
            CreateMap<UOMConversion, UOMConversionModel>()
                .ForMember(dest => dest.FromUOMCode, opts => opts.MapFrom(src => src.FromUOM.Code))
                .ForMember(dest => dest.FromUOMName, opts => opts.MapFrom(src => src.FromUOM.Name))
                .ForMember(dest => dest.ToUOMCode, opts => opts.MapFrom(src => src.ToUOM.Code))
                .ForMember(dest => dest.ToUOMName, opts => opts.MapFrom(src => src.ToUOM.Name))
                .ReverseMap();
            CreateMap<CreateUOMConversionCommand, UOMConversion>();
            CreateMap<GetUOMConversionsQuery, UOMConversionParameter>();
        }
    }
}
