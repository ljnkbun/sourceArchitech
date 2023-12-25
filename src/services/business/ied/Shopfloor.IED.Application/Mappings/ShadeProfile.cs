using AutoMapper;
using Shopfloor.IED.Application.Command.Shades;
using Shopfloor.IED.Application.Models.Shades;
using Shopfloor.IED.Application.Parameters.Shades;
using Shopfloor.IED.Application.Query.Shades;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Shades
{
    public class ShadeProfile : Profile
    {
        public ShadeProfile()
        {
            CreateMap<Shade, ShadeModel>().ReverseMap();
            CreateMap<CreateShadeCommand, Shade>();
            CreateMap<GetShadesQuery, ShadeParameter>();
        }
    }
}
