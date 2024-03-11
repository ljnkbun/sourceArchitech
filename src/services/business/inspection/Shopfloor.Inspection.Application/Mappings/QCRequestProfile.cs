using AutoMapper;
using Shopfloor.Inspection.Application.Command.QCRequests;
using Shopfloor.Inspection.Application.Models.QCRequests;
using Shopfloor.Inspection.Application.Parameters.QCRequests;
using Shopfloor.Inspection.Application.Query.QCRequests;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Application.QCRequests
{
    public class QCRequestProfile : Profile
    {
        public QCRequestProfile()
        {
            CreateMap<QCRequest, QCRequestModel>().ReverseMap();
            CreateMap<CreateQCRequestCommand, QCRequest>();
            CreateMap<GetQCRequestsQuery, QCRequestParameter>();
        }
    }
}
