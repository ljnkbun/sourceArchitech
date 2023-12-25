using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingRappoMatrics;
using Shopfloor.IED.Application.Models.WeavingRappoMatrics;
using Shopfloor.IED.Application.Parameters.WeavingRappoMatrics;
using Shopfloor.IED.Application.Query.WeavingRappoMatrics;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.WeavingRappoMatrics
{
    public class WeavingRappoMatricProfile : Profile
    {
        public WeavingRappoMatricProfile()
        {
            CreateMap<WeavingRappoMatric, WeavingRappoMatricModel>().ReverseMap();
            CreateMap<CreateWeavingRappoMatricCommand, WeavingRappoMatric>();
            CreateMap<GetWeavingRappoMatricsQuery, WeavingRappoMatricParameter>();
        }
    }
}
