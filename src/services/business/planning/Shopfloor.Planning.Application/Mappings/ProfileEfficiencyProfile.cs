using AutoMapper;
using Shopfloor.Planning.Application.Command.ProfileEfficiencies;
using Shopfloor.Planning.Application.Models.ProfileEfficiencies;
using Shopfloor.Planning.Application.Parameters.ProfileEfficiencies;
using Shopfloor.Planning.Application.Query.ProfileEfficiencies;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ProfileEfficiencyProfile : Profile
    {
        public ProfileEfficiencyProfile()
        {
            CreateMap<ProfileEfficiency, ProfileEfficiencyModel>();
            CreateMap<ProfileEfficiency, CreateProfileEfficiencyCommand>();
            CreateMap<GetProfileEfficienciesQuery, ProfileEfficiencyParameter>();
            CreateMap<CreateProfileEfficiencyCommand, ProfileEfficiency>();
        }
    }
}
