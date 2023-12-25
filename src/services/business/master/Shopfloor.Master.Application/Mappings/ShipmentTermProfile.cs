using AutoMapper;
using Shopfloor.Master.Application.Command.ShipmentTerms;
using Shopfloor.Master.Application.Models.ShipmentTerms;
using Shopfloor.Master.Application.Parameters.ShipmentTerms;
using Shopfloor.Master.Application.Query.ShipmentTerms;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Application.ShipmentTerms
{
    public class ShipmentTermProfile : Profile
    {
        public ShipmentTermProfile()
        {
            CreateMap<ShipmentTerm, ShipmentTermModel>().ReverseMap();
            CreateMap<CreateShipmentTermCommand, ShipmentTerm>();
            CreateMap<GetShipmentTermsQuery, ShipmentTermParameter>();
        }
    }
}
