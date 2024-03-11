using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingRoutings;
using Shopfloor.IED.Application.Models.WeavingRoutings;
using Shopfloor.IED.Application.Parameters.WeavingRoutings;
using Shopfloor.IED.Application.Query.WeavingRoutings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingRoutings
{
    public class WeavingRoutingProfile : Profile
    {
        public WeavingRoutingProfile()
        {
            CreateMap<WeavingRouting, WeavingRoutingModel>().ReverseMap();
            CreateMap<CreateWeavingRoutingCommand, WeavingRouting>();
            CreateMap<UpdateWeavingRoutingCommand, WeavingRouting>();
            CreateMap<GetWeavingRoutingsQuery, WeavingRoutingParameter>();
        }
    }
}