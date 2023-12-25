using AutoMapper;
using Shopfloor.IED.Application.Command.SewingSubOperationWFXs;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXBOLs;
using Shopfloor.IED.Application.Models.SewingSubOperationWFXs;
using Shopfloor.IED.Application.Parameters.SewingSubOperationWFXs;
using Shopfloor.IED.Application.Query.SewingSubOperationWFXs;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingSubOperationWFXs
{
    public class SewingSubOperationWFXProfile : Profile
    {
        public SewingSubOperationWFXProfile()
        {
            CreateMap<SewingSubOperationWFX, SewingSubOperationWFXModel>().ReverseMap();
            CreateMap<CreateSewingSubOperationWFXCommand, SewingSubOperationWFX>();
            CreateMap<GetSewingSubOperationWFXsQuery, SewingSubOperationWFXParameter>();
            CreateMap<SewingSubOperationWFXBOLModel, SewingSubOperationWFXBOL>();
        }
    }
}
