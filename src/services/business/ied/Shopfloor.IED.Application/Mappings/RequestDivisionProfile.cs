using AutoMapper;
using Shopfloor.IED.Application.Command.RequestDivisions;
using Shopfloor.IED.Application.Models.RequestDivisions;
using Shopfloor.IED.Application.Parameters.RequestDivisions;
using Shopfloor.IED.Application.Query.RequestDivisions;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RequestDivisions
{
    public class RequestDivisionProfile : Profile
    {
        public RequestDivisionProfile()
        {
            CreateMap<RequestDivision, RequestDivisionModel>().ReverseMap();
            CreateMap<CreateRequestDivisionCommand, RequestDivision>();
            CreateMap<UpdateRequestDivisionCommand, RequestDivision>();
            CreateMap<GetRequestDivisionsQuery, RequestDivisionParameter>();
        }
    }
}
