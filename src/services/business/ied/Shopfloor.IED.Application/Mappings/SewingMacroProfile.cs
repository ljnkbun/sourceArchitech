using AutoMapper;
using Shopfloor.IED.Application.Command.SewingMacros;
using Shopfloor.IED.Application.Models.SewingMacroBOLs;
using Shopfloor.IED.Application.Models.SewingMacros;
using Shopfloor.IED.Application.Parameters.SewingMacros;
using Shopfloor.IED.Application.Query.SewingMacros;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingMacros
{
    public class SewingMacroProfile : Profile
    {
        public SewingMacroProfile()
        {
            CreateMap<SewingMacro, SewingMacroModel>().ReverseMap();
            CreateMap<CreateSewingMacroCommand, SewingMacro>();
            CreateMap<GetSewingMacrosQuery, SewingMacroParameter>();
            CreateMap<SewingMacroBOLModel, SewingMacroBOL>();
        }
    }
}
