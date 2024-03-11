using AutoMapper;
using Shopfloor.Planning.Application.Command.CapacityColors;
using Shopfloor.Planning.Application.Models.CapacityColors;
using Shopfloor.Planning.Application.Parameters.CapacityColors;
using Shopfloor.Planning.Application.Query.CapacityColors;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Application.CapacityColors
{
    public class CapacityColorProfile : Profile
    {
        public CapacityColorProfile()
        {
            CreateMap<CapacityColor, CapacityColorModel>().ReverseMap();
            CreateMap<CreateCapacityColorCommand, CapacityColor>();
            CreateMap<GetCapacityColorsQuery, CapacityColorParameter>();
        }
    }
}
