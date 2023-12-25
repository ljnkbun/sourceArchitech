using AutoMapper;
using Shopfloor.IED.Application.Command.RequestTypes;
using Shopfloor.IED.Application.Models.RequestTypes;
using Shopfloor.IED.Application.Parameters.RequestTypes;
using Shopfloor.IED.Application.Query.RequestTypes;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RequestTypes
{
    public class RequestTypeProfile : Profile
    {
        public RequestTypeProfile()
        {
            CreateMap<RequestType, RequestTypeModel>().ReverseMap();
            CreateMap<CreateRequestTypeCommand, RequestType>();
            CreateMap<GetRequestTypesQuery, RequestTypeParameter>();
        }
    }
}
