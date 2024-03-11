using AutoMapper;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Application.Models.SewingMacroLibBOLs;
using Shopfloor.IED.Application.Models.SewingMacroLibs;
using Shopfloor.IED.Application.Models.SewingTaskLibs;
using Shopfloor.IED.Application.Parameters.SewingMacroLibs;
using Shopfloor.IED.Application.Query.SewingMacroLibs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.SewingMacroLibs
{
    public class SewingMacroLibProfile : Profile
    {
        public SewingMacroLibProfile()
        {
            CreateMap<CreateSewingMacroLibCommand, SewingMacroLib>();
            CreateMap<GetSewingMacroLibsQuery, SewingMacroLibParameter>();
            CreateMap<SewingMacroLibBOLModel, SewingMacroLibBOL>();
            CreateMap<SewingMacroLib, SewingMacroLibModel>()
                .ForMember(dest => dest.BundleQuality,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMacroLibBOLs.FirstOrDefault(t => t.Type == MacroBOLType.MN).SewingTaskLib.SewingBundle.Quantity))
                .ForMember(dest => dest.PersonalAllowance,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMacroLibBOLs.FirstOrDefault(t => t.Type == MacroBOLType.MN).SewingTaskLib.SewingMachineEfficiencyProfile.SewingEfficiencyProfile.PersonalAllowance))
                .ForMember(dest => dest.MachineDelay,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMacroLibBOLs.FirstOrDefault(t => t.Type == MacroBOLType.MN).SewingTaskLib.SewingMachineEfficiencyProfile.SewingEfficiencyProfile.MachineDelay))
                .ForMember(dest => dest.Contingency,
                    otp => otp.MapFrom(x => (decimal?)x.SewingMacroLibBOLs.FirstOrDefault(t => t.Type == MacroBOLType.MN).SewingTaskLib.SewingMachineEfficiencyProfile.SewingEfficiencyProfile.Contingency));
        }
    }
}
