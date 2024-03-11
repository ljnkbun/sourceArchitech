using AutoMapper;
using Shopfloor.IED.Application.Command.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Models.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Parameters.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Query.SewingEfficiencyProfiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class SewingEfficiencyProfileProfile : Profile
    {
        public SewingEfficiencyProfileProfile()
        {
            CreateMap<SewingEfficiencyProfile, SewingEfficiencyProfileModel>().ReverseMap();
            CreateMap<CreateSewingEfficiencyProfileCommand, SewingEfficiencyProfile>();
            CreateMap<UpdateSewingEfficiencyProfileCommand, SewingEfficiencyProfile>();
            CreateMap<GetSewingEfficiencyProfilesQuery, SewingEfficiencyProfileParameter>();
        }
    }
}