using AutoMapper;
using Shopfloor.IED.Application.Command.Lights;
using Shopfloor.IED.Application.Models.Lights;
using Shopfloor.IED.Application.Parameters.Lights;
using Shopfloor.IED.Application.Query.Lights;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Lights
{
    public class LightProfile : Profile
    {
        public LightProfile()
        {
            CreateMap<Light, LightModel>().ReverseMap();
            CreateMap<CreateLightCommand, Light>();
            CreateMap<GetLightsQuery, LightParameter>();
        }
    }
}
