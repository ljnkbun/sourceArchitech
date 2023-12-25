using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingRappos;
using Shopfloor.IED.Application.Models.WeavingRappos;
using Shopfloor.IED.Application.Parameters.WeavingRappos;
using Shopfloor.IED.Application.Query.WeavingRappos;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingRappos
{
    public class WeavingRappoProfile : Profile
    {
        public WeavingRappoProfile()
        {
            CreateMap<WeavingRappo, WeavingRappoModel>().ReverseMap();
            CreateMap<CreateWeavingRappoCommand, WeavingRappo>();
            CreateMap<GetWeavingRapposQuery, WeavingRappoParameter>();
        }
    }
}
