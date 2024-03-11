using AutoMapper;
using Shopfloor.IED.Application.Command.SewingTaskLibs;
using Shopfloor.IED.Application.Models.SewingTaskLibs;
using Shopfloor.IED.Application.Parameters.SewingTaskLibs;
using Shopfloor.IED.Application.Query.SewingTaskLibs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingTaskLibs
{
    public class SewingTaskLibProfile : Profile
    {
        public SewingTaskLibProfile()
        {
            CreateMap<CreateSewingTaskLibCommand, SewingTaskLib>();
            CreateMap<GetSewingTaskLibsQuery, SewingTaskLibParameter>();
            CreateMap<SewingTaskLib, SewingTaskLibModel>()
                .ForMember(dest => dest.BundleQuality,
                    otp => otp.MapFrom(x => (decimal?)x.SewingBundle.Quantity))
                .ForMember(dest => dest.PersonalAllowance,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMachineEfficiencyProfile.SewingEfficiencyProfile.PersonalAllowance))
                .ForMember(dest => dest.MachineDelay,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMachineEfficiencyProfile.SewingEfficiencyProfile.MachineDelay))
                .ForMember(dest => dest.Contingency,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMachineEfficiencyProfile.SewingEfficiencyProfile.Contingency));
        }
    }
}
