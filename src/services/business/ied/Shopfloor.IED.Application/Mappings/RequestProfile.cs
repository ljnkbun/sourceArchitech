using AutoMapper;
using Shopfloor.IED.Application.Command.Requests;
using Shopfloor.IED.Application.Models.Requests;
using Shopfloor.IED.Application.Parameters.Requests;
using Shopfloor.IED.Application.Query.Requests;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.Requests
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Request, RequestModel>().ReverseMap();
            CreateMap<CreateRequestCommand, Request>();
            CreateMap<GetRequestsQuery, RequestIEDParameter>();
        }
    }
}
