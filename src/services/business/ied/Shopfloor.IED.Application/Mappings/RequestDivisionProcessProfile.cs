using AutoMapper;
using Shopfloor.IED.Application.Command.RequestDivisionProcesses;
using Shopfloor.IED.Application.Models.RequestDivisionProcesses;
using Shopfloor.IED.Application.Parameters.RequestDivisionProcesses;
using Shopfloor.IED.Application.Query.RequestDivisionProcesses;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RequestDivisionProcesses
{
    public class RequestDivisionProcessProfile : Profile
    {
        public RequestDivisionProcessProfile()
        {
            CreateMap<RequestDivisionProcess, RequestDivisionProcessModel>().ReverseMap();
            CreateMap<CreateRequestDivisionProcessCommand, RequestDivisionProcess>();
            CreateMap<UpdateRequestDivisionProcessCommand, RequestDivisionProcess>();
            CreateMap<GetRequestDivisionProcessesQuery, RequestDivisionProcessParameter>();
        }
    }
}
