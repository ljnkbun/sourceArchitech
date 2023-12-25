using AutoMapper;
using Shopfloor.IED.Application.Command.SewingFeatures;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Application.Models.SewingFeatureBOLs;
using Shopfloor.IED.Application.Models.SewingFeatures;
using Shopfloor.IED.Application.Models.SewingOperationLibBOLs;
using Shopfloor.IED.Application.Parameters.SewingFeatures;
using Shopfloor.IED.Application.Query.SewingFeatures;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingFeatures
{
    public class SewingFeatureProfile : Profile
    {
        public SewingFeatureProfile()
        {
            CreateMap<SewingFeature, SewingFeatureModel>().ReverseMap();
            CreateMap<CreateSewingFeatureCommand, SewingFeature>();
            CreateMap<GetSewingFeaturesQuery, SewingFeatureParameter>();
            CreateMap<SewingFeatureBOLModel, SewingFeatureBOL>();
        }
    }
}
