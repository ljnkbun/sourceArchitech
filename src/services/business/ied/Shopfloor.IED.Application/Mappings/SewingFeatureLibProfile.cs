using AutoMapper;
using Shopfloor.IED.Application.Command.SewingFeatureLibs;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Application.Models.SewingFeatureLibBOLs;
using Shopfloor.IED.Application.Models.SewingFeatureLibs;
using Shopfloor.IED.Application.Models.SewingOperationLibBOLs;
using Shopfloor.IED.Application.Parameters.SewingFeatureLibs;
using Shopfloor.IED.Application.Query.SewingFeatureLibs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingFeatureLibs
{
    public class SewingFeatureLibProfile : Profile
    {
        public SewingFeatureLibProfile()
        {
            CreateMap<SewingFeatureLib, SewingFeatureLibModel>().ReverseMap();
            CreateMap<CreateSewingFeatureLibCommand, SewingFeatureLib>();
            CreateMap<GetSewingFeatureLibsQuery, SewingFeatureLibParameter>();
            CreateMap<SewingFeatureLibBOLModel, SewingFeatureLibBOL>();
        }
    }
}
