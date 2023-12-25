using AutoMapper;
using Shopfloor.Barcode.Application.Command.Locations;
using Shopfloor.Barcode.Application.Models.Locations;
using Shopfloor.Barcode.Application.Parameters.Locations;
using Shopfloor.Barcode.Application.Query.Locations;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Locations
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationModel>().ReverseMap();
            CreateMap<CreateLocationCommand, Location>();
            CreateMap<GetLocationsQuery, LocationParameter>();
        }
    }
}
