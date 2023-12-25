using AutoMapper;
using Shopfloor.IED.Application.Command.SewingOperationWFXs;
using Shopfloor.IED.Application.Models.SewingOperationWFXs;
using Shopfloor.IED.Application.Parameters.SewingOperationWFXs;
using Shopfloor.IED.Application.Query.SewingOperationWFXs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingOperationWFXs
{
    public class SewingOperationWFXProfile : Profile
    {
        public SewingOperationWFXProfile()
        {
            CreateMap<SewingOperationWFX, SewingOperationWFXModel>().ReverseMap();
            CreateMap<CreateSewingOperationWFXCommand, SewingOperationWFX>();
            CreateMap<GetSewingOperationWFXsQuery, SewingOperationWFXParameter>();
            CreateMap<SewingOperationWFXVersion, VersionModel>();
        }
    }
}
