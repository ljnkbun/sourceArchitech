using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingBackgrounStyles;
using Shopfloor.IED.Application.Models.WeavingBackgrounStyles;
using Shopfloor.IED.Application.Parameters.WeavingBackgrounStyles;
using Shopfloor.IED.Application.Query.WeavingBackgrounStyles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingBackgrounStyles
{
    public class WeavingBackgrounStyleProfile : Profile
    {
        public WeavingBackgrounStyleProfile()
        {
            CreateMap<WeavingBackgrounStyle, WeavingBackgrounStyleModel>().ReverseMap();
            CreateMap<CreateWeavingBackgrounStyleCommand, WeavingBackgrounStyle>();
            CreateMap<GetWeavingBackgrounStylesQuery, WeavingBackgrounStyleParameter>();
        }
    }
}
