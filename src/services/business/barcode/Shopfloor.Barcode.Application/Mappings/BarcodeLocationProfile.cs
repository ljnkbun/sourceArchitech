using AutoMapper;
using Shopfloor.Barcode.Application.Command.BarcodeLocations;
using Shopfloor.Barcode.Application.Models.BarcodeLocations;
using Shopfloor.Barcode.Application.Parameters.BarcodeLocations;
using Shopfloor.Barcode.Application.Query.BarcodeLocations;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.BarcodeLocations
{
    public class BarcodeLocationProfile : Profile
    {
        public BarcodeLocationProfile()
        {
            CreateMap<BarcodeLocation, BarcodeLocationModel>().ReverseMap();
            CreateMap<CreateBarcodeLocationCommand, BarcodeLocation>();
            CreateMap<GetBarcodeLocationsQuery, BarcodeLocationParameter>();
        }
    }
}
