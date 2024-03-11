using AutoMapper;
using Shopfloor.IED.Application.Command.WeavingOperations;
using Shopfloor.IED.Application.Models.WeavingOperations;
using Shopfloor.IED.Application.Parameters.WeavingOperations;
using Shopfloor.IED.Application.Query.WeavingOperations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Mappings
{
    public class WeavingOperationProfile : Profile
    {
        public WeavingOperationProfile()
        {
            CreateMap<WeavingOperation, WeavingOperationModel>().ReverseMap();
            CreateMap<CreateWeavingOperationCommand, WeavingOperation>();
            CreateMap<UpdateWeavingOperationCommand, WeavingOperation>();
            CreateMap<GetWeavingOperationsQuery, WeavingOperationParameter>();
        }
    }
}