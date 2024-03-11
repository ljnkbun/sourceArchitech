using AutoMapper;
using Shopfloor.Inspection.Application.Command.AQLVersions;
using Shopfloor.Inspection.Application.Models.AQLVersions;
using Shopfloor.Inspection.Application.Parameters.AQLVersions;
using Shopfloor.Inspection.Application.Query.AQLVersions;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.AQLVersions
{
    public class AQLVersionProfile : Profile
    {
        public AQLVersionProfile()
        {
            CreateMap<AQLVersion, AQLVersionModel>().ReverseMap();
            CreateMap<CreateAQLVersionCommand, AQLVersion>();
            CreateMap<GetAQLVersionsQuery, AQLVersionParameter>();
        }
    }
}
