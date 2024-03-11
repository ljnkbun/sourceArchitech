using AutoMapper;
using Shopfloor.IED.Application.Command.SewingRoutings;
using Shopfloor.IED.Application.Models.SewingRoutingBOLs;
using Shopfloor.IED.Application.Models.SewingRoutings;
using Shopfloor.IED.Application.Parameters.SewingRoutings;
using Shopfloor.IED.Application.Query.SewingRoutings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingRoutings
{
    public class SewingRoutingProfile : Profile
    {
        public SewingRoutingProfile()
        {
            CreateMap<SewingRouting, SewingRoutingModel>().ReverseMap();
            CreateMap<CreateSewingRoutingCommand, SewingRouting>();
            CreateMap<GetSewingRoutingsQuery, SewingRoutingParameter>();
            CreateMap<SewingRoutingBOLModel, SewingRoutingBOL>();
            CreateMap<SewingRouting, GetSewingRoutingModel>();
        }
    }
}
