using AutoMapper;
using Shopfloor.IED.Application.Command.SewingBundles;
using Shopfloor.IED.Application.Models.SewingBundles;
using Shopfloor.IED.Application.Parameters.SewingBundles;
using Shopfloor.IED.Application.Query.SewingBundles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class SewingBundleProfile : Profile
    {
        public SewingBundleProfile()
        {
            CreateMap<SewingBundle, SewingBundleModel>().ReverseMap();
            CreateMap<CreateSewingBundleCommand, SewingBundle>();
            CreateMap<GetSewingBundlesQuery, SewingBundleParameter>();
        }
    }
}