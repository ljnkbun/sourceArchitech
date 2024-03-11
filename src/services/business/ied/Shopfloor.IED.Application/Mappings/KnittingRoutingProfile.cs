using AutoMapper;
using Shopfloor.IED.Application.Command.KnittingRoutings;
using Shopfloor.IED.Application.Models.KnittingRoutings;
using Shopfloor.IED.Application.Parameters.KnittingRoutings;
using Shopfloor.IED.Application.Query.KnittingRoutings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.KnittingRoutings
{
    public class KnittingRoutingProfile : Profile
    {
        public KnittingRoutingProfile()
        {
            CreateMap<KnittingRouting, KnittingRoutingModel>().ReverseMap();
            CreateMap<CreateKnittingRoutingCommand, KnittingRouting>();
            CreateMap<GetKnittingRoutingsQuery, KnittingRoutingParameter>();
        }
    }
}
