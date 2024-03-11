using AutoMapper;
using Shopfloor.Barcode.Application.Command.AppVersions;
using Shopfloor.Barcode.Application.Models.AppVersions;
using Shopfloor.Barcode.Application.Parameters.AppVersions;
using Shopfloor.Barcode.Application.Query.AppVersions;
using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Mappings
{
    public class AppVersionProfile : Profile
    {
        public AppVersionProfile()
        {
            CreateMap<AppVersion, AppVersionModel>().ReverseMap();
            CreateMap<CreateAppVersionCommand, AppVersion>();
            CreateMap<GetAppVersionsQuery, AppVersionParameter>();
        }
    }
}