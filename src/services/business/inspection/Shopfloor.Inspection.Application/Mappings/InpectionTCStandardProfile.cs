using AutoMapper;
using Shopfloor.Inspection.Application.Command.InpectionTCStandards;
using Shopfloor.Inspection.Application.Models.InpectionTCStandards;
using Shopfloor.Inspection.Application.Parameters.InpectionTCStandards;
using Shopfloor.Inspection.Application.Query.InpectionTCStandards;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.InpectionTCStandards
{
    public class InpectionTCStandardProfile : Profile
    {
        public InpectionTCStandardProfile()
        {
            CreateMap<InpectionTCStandard, InpectionTCStandardModel>().ReverseMap();
            CreateMap<CreateInpectionTCStandardCommand, InpectionTCStandard>();
            CreateMap<GetInpectionTCStandardsQuery, InpectionTCStandardParameter>();
        }
    }
}
