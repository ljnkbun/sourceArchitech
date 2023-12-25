using AutoMapper;
using Shopfloor.IED.Application.Command.RequestDivisionFiles;
using Shopfloor.IED.Application.Models.RequestDivisionFiles;
using Shopfloor.IED.Application.Parameters.RequestDivisionFiles;
using Shopfloor.IED.Application.Query.RequestDivisionFiles;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Application.RequestDivisionFiles
{
    public class RequestDivisionFileProfile : Profile
    {
        public RequestDivisionFileProfile()
        {
            CreateMap<RequestDivisionFile, RequestDivisionFileModel>().ReverseMap();
            CreateMap<CreateRequestDivisionFileCommand, RequestDivisionFile>();
            CreateMap<GetRequestDivisionFilesQuery, RequestDivisionFileParameter>();
        }
    }
}
