using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingYarns;
using Shopfloor.IED.Application.Models.WeavingYarns;
using Shopfloor.IED.Application.Parameters.WeavingYarns;
using Shopfloor.IED.Application.Query.WeavingYarns;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingYarns
{
    public class WeavingYarnProfile : Profile
    {
        public WeavingYarnProfile()
        {
            CreateMap<WeavingYarn, WeavingYarnModel>().ReverseMap();
            CreateMap<CreateWeavingYarnCommand, WeavingYarn>();
            CreateMap<GetWeavingYarnsQuery, WeavingYarnParameter>();
        }
    }
}
