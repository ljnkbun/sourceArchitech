using AutoMapper;
using Shopfloor.IED.Application.Command.DyeingTBRequests;
using Shopfloor.IED.Application.Models.DyeingTBRequests;
using Shopfloor.IED.Application.Parameters.DyeingTBRequests;
using Shopfloor.IED.Application.Query.DyeingTBRequests;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class DyeingTBRequestProfile : Profile
    {
        public DyeingTBRequestProfile()
        {
            CreateMap<DyeingTBRequest, DyeingTBRequestModel>().ReverseMap();
            CreateMap<CreateDyeingTBRequestCommand, DyeingTBRequest>();
            CreateMap<GetDyeingTBRequestsQuery, DyeingTBRequestParameter>();
        }
    }
}