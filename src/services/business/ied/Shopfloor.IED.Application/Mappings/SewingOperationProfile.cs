using AutoMapper;
using Shopfloor.IED.Application.Command.SewingOperations;
using Shopfloor.IED.Application.Models.SewingOperationBOLs;
using Shopfloor.IED.Application.Models.SewingOperations;
using Shopfloor.IED.Application.Parameters.SewingOperations;
using Shopfloor.IED.Application.Query.SewingOperations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.SewingOperations
{
    public class SewingOperationProfile : Profile
    {
        public SewingOperationProfile()
        {
            CreateMap<SewingOperation, SewingOperationModel>().ReverseMap();
            CreateMap<CreateSewingOperationCommand, SewingOperation>();
            CreateMap<GetSewingOperationsQuery, SewingOperationParameter>();
            CreateMap<SewingOperationBOLModel, SewingOperationBOL>();
        }
    }
}
