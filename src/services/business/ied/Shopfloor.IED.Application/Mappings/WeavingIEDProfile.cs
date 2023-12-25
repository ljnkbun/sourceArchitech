using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingIEDs;
using Shopfloor.IED.Application.Models.WeavingIEDs;
using Shopfloor.IED.Application.Parameters.WeavingIEDs;
using Shopfloor.IED.Application.Query.WeavingIEDs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingIEDs
{
    public class WeavingIEDProfile : Profile
    {
        public WeavingIEDProfile()
        {
            CreateMap<WeavingIED, WeavingIEDModel>().ReverseMap();
            CreateMap<CreateWeavingIEDCommand, WeavingIED>();
            CreateMap<GetWeavingIEDsQuery, WeavingIEDParameter>();
        }
    }
}
