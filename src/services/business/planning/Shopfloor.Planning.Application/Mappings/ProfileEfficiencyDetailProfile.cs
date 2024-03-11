using AutoMapper;
using Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails;
using Shopfloor.Planning.Application.Models.ProfileEfficiencyDetails;
using Shopfloor.Planning.Application.Parameters.ProfileEfficiencyDetails;
using Shopfloor.Planning.Application.Query.ProfileEfficiencyDetails;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Master.Application.Mappings
{
    public class ProfileEfficiencyDetailProfile : Profile
    {
        public ProfileEfficiencyDetailProfile()
        {
            CreateMap<ProfileEfficiencyDetail, ProfileEfficiencyDetailModel>();
            CreateMap<CreateProfileEfficiencyDetailCommand, ProfileEfficiencyDetail>();
            CreateMap<UpdateProfileEfficiencyDetailCommand, ProfileEfficiencyDetail>();
            CreateMap<GetProfileEfficiencyDetailsQuery, ProfileEfficiencyDetailParameter>();
        }
    }
}
