using AutoMapper;
using Shopfloor.Inspection.Application.Command.Conversions;
using Shopfloor.Inspection.Application.Models.Conversions;
using Shopfloor.Inspection.Application.Parameters.Conversions;
using Shopfloor.Inspection.Application.Query.Conversions;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.Conversions
{
    public class ConversionProfile : Profile
    {
        public ConversionProfile()
        {
            CreateMap<Conversion, ConversionModel>().ReverseMap();
            CreateMap<CreateConversionCommand, Conversion>();
            CreateMap<GetConversionsQuery, ConversionParameter>();
        }
    }
}
