using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingBackgroundStyles;
using Shopfloor.IED.Application.Models.WeavingBackgroundStyles;
using Shopfloor.IED.Application.Parameters.WeavingBackgroundStyles;
using Shopfloor.IED.Application.Query.WeavingBackgroundStyles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingBackgroundStyles
{
    public class WeavingBackgroundStyleProfile : Profile
    {
        public WeavingBackgroundStyleProfile()
        {
            CreateMap<WeavingBackgroundStyle, WeavingBackgroundStyleModel>().ReverseMap();
            CreateMap<CreateWeavingBackgroundStyleCommand, WeavingBackgroundStyle>();
            CreateMap<GetWeavingBackgroundStylesQuery, WeavingBackgroundStyleParameter>();
        }
    }
}
