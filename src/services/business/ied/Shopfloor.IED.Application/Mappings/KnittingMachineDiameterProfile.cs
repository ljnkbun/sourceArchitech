using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingMachineDiameters;
using Shopfloor.IED.Application.Models.KnittingMachineDiameters;
using Shopfloor.IED.Application.Parameters.KnittingMachineDiameters;
using Shopfloor.IED.Application.Query.KnittingMachineDiameters;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingMachineDiameters
{
    public class KnittingMachineDiameterProfile : Profile
    {
        public KnittingMachineDiameterProfile()
        {
            CreateMap<KnittingMachineDiameter, KnittingMachineDiameterModel>().ReverseMap();
            CreateMap<CreateKnittingMachineDiameterCommand, KnittingMachineDiameter>();
            CreateMap<GetKnittingMachineDiametersQuery, KnittingMachineDiameterParameter>();
        }
    }
}
