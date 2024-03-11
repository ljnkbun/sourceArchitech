using AutoMapper;
using Shopfloor.Inspection.Application.Command.AQLs;
using Shopfloor.Inspection.Application.Models.AQLs;
using Shopfloor.Inspection.Application.Parameters.AQLs;
using Shopfloor.Inspection.Application.Query.AQLs;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.AQLs
{
    public class AQLProfile : Profile
    {
        public AQLProfile()
        {
            CreateMap<AQL, AQLModel>().ReverseMap();
            CreateMap<CreateAQLCommand, AQL>();
            CreateMap<UpdateAQLCommand, AQL>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<GetAQLsQuery, AQLParameter>();
        }
    }
}
