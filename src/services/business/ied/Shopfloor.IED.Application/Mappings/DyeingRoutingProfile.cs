using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingRoutings;
using Shopfloor.IED.Application.Models.DyeingRoutings;
using Shopfloor.IED.Application.Parameters.DyeingRoutings;
using Shopfloor.IED.Application.Query.DyeingRoutings;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingRoutingProfile : Profile
    {
        public DyeingRoutingProfile()
        {
            CreateMap<DyeingRouting, DyeingRoutingModel>().ReverseMap();
            CreateMap<CreateDyeingRoutingCommand, DyeingRouting>();
            CreateMap<GetDyeingRoutingsQuery, DyeingRoutingParameter>();
        }
    }
}