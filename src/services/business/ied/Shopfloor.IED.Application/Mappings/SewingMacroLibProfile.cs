using AutoMapper;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Application.Models.SewingMacroLibBOLs;
using Shopfloor.IED.Application.Models.SewingMacroLibs;
using Shopfloor.IED.Application.Parameters.SewingMacroLibs;
using Shopfloor.IED.Application.Query.SewingMacroLibs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingMacroLibs
{
    public class SewingMacroLibProfile : Profile
    {
        public SewingMacroLibProfile()
        {
            CreateMap<SewingMacroLib, SewingMacroLibModel>().ReverseMap();
            CreateMap<CreateSewingMacroLibCommand, SewingMacroLib>();
            CreateMap<GetSewingMacroLibsQuery, SewingMacroLibParameter>();
            CreateMap<SewingMacroLibBOLModel, SewingMacroLibBOL>();
        }
    }
}
