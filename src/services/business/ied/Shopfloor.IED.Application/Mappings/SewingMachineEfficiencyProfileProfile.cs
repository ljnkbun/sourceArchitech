using AutoMapper;
using Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Models.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Parameters.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Application.Query.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class SewingMachineEfficiencyProfileProfile : Profile
    {
        public SewingMachineEfficiencyProfileProfile()
        {
            CreateMap<SewingMachineEfficiencyProfile, SewingMachineEfficiencyProfileModel>().ReverseMap();
            CreateMap<CreateSewingMachineEfficiencyProfileCommand, SewingMachineEfficiencyProfile>();
            CreateMap<UpdateSewingMachineEfficiencyProfileCommand, SewingMachineEfficiencyProfile>();
            CreateMap<GetSewingMachineEfficiencyProfilesQuery, SewingMachineEfficiencyProfileParameter>();
        }
    }
}