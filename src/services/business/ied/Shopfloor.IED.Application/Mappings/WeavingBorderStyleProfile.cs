using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingBorderStyles;
using Shopfloor.IED.Application.Models.WeavingBorderStyles;
using Shopfloor.IED.Application.Parameters.WeavingBorderStyles;
using Shopfloor.IED.Application.Query.WeavingBorderStyles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingBorderStyles
{
    public class WeavingBorderStyleProfile : Profile
    {
        public WeavingBorderStyleProfile()
        {
            CreateMap<WeavingBorderStyle, WeavingBorderStyleModel>().ReverseMap();
            CreateMap<CreateWeavingBorderStyleCommand, WeavingBorderStyle>();
            CreateMap<GetWeavingBorderStylesQuery, WeavingBorderStyleParameter>();
        }
    }
}
