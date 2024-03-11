using AutoMapper;
using Shopfloor.Inspection.Application.Command.ZoneTypes;
using Shopfloor.Inspection.Application.Models.ZoneTypes;
using Shopfloor.Inspection.Application.Parameters.ZoneTypes;
using Shopfloor.Inspection.Application.Query.ZoneTypes;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.ZoneTypes
{
    public class ZoneTypeProfile : Profile
    {
        public ZoneTypeProfile()
        {
            CreateMap<ZoneType, ZoneTypeModel>().ReverseMap();
            CreateMap<CreateZoneTypeCommand, ZoneType>();
            CreateMap<GetZoneTypesQuery, ZoneTypeParameter>();
        }
    }
}
