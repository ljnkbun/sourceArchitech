using AutoMapper;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Application.Models.Zones;
using Shopfloor.IED.Application.Parameters.Zones;
using Shopfloor.IED.Application.Query.Zones;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Zones
{
    public class ZoneProfile : Profile
    {
        public ZoneProfile()
        {
            CreateMap<Zone, ZoneModel>().ReverseMap();
            CreateMap<CreateZoneCommand, Zone>();
            CreateMap<GetZonesQuery, ZoneParameter>();
        }
    }
}
